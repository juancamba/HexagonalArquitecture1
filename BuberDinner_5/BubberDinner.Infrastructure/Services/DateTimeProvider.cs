using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BubberDinner.Application.Common.Interfaces.Services;

namespace BubberDinner.Infrastructure.Services
{
    public class DateTimeProvider : IDateTimeProvider
    {
        public DateTime UtcNow => DateTime.UtcNow;
    }
}