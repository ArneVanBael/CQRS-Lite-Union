using CQRS_Lite_Union_API.Application.Abstractions;
using CQRS_Lite_Union_API.Application.Attendees.Queries;
using CQRS_Lite_Union_API.Application.Attendees.Result;
using CQRS_Lite_Union_API.Application.Utils;
using CQRS_Lite_Union_API.Common.Response;
using Microsoft.Extensions.Caching.Memory;
using System;
using System.Threading;
using System.Threading.Tasks;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace CQRS_Lite_Union_API.Application.Attendees.QueryHandlers
{
    public class GetAverageAttendeesPerWorkshopQueryHandler : QueryHandlerBase<GetAverageAttendeesPerWorkshopQuery, AverageAttendeesPerWorkshopResult>
    {
        private readonly IMemoryCache _cache;
        private const string CACHEKEY = "averagePerWorkshop";

        public GetAverageAttendeesPerWorkshopQueryHandler(IAppContext context, IMemoryCache memoryCache) : base(context)
        {
            _cache = memoryCache;
        }

        protected async override Task<IResponse<AverageAttendeesPerWorkshopResult>> HandleAsync(GetAverageAttendeesPerWorkshopQuery query, CancellationToken cancellationToken)
        {
            var averageResult = await GetFromCacheOrCalculate();
            return Response.Ok(averageResult);
        }

        private async Task<AverageAttendeesPerWorkshopResult> CalculateAverage()
        {
            var totalAttendees = await Context.AttendeeQueryRepository.CountAsync();
            var totalWorkshops = await Context.WorkshopsQueryRepository.CountAsync();
            var average = totalAttendees / totalWorkshops;

            return new AverageAttendeesPerWorkshopResult(totalWorkshops, totalAttendees, average);
        }

        private async Task<AverageAttendeesPerWorkshopResult> GetFromCacheOrCalculate()
        {
            if(!_cache.TryGetValue(CACHEKEY, out AverageAttendeesPerWorkshopResult cacheResult)) {
                // recalculate
                var averageResult = await CalculateAverage();
                _cache.Set(CACHEKEY, averageResult, new MemoryCacheEntryOptions { AbsoluteExpirationRelativeToNow = TimeSpan.FromHours(1)});
                return averageResult;
            } else
            {
                // load from cache
                return cacheResult;
            }
        }
    }
}
