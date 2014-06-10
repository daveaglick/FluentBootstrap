using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FluentBootstrap
{
    public enum FormInputType
    {
        [Description("text")]
        Text,
        [Description("password")]
        Password,
        [Description("datetime")]
        DateTime,
        [Description("datetime-local")]
        DateTimeLocal,
        [Description("date")]
        Date,
        [Description("month")]
        Month,
        [Description("time")]
        Time,
        [Description("week")]
        Week,
        [Description("number")]
        Number,
        [Description("email")]
        Email,
        [Description("url")]
        Url,
        [Description("search")]
        Search,
        [Description("tel")]
        Tel,
        [Description("color")]
        Color
    }
}
