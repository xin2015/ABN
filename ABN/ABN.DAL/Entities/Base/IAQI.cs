using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ABN.DAL.Entities
{
    /// <summary>
    /// 空气质量指数/空气质量综合指数接口
    /// </summary>
    public interface IAQI
    {
        /// <summary>
        /// 空气质量指数/空气质量综合指数
        /// </summary>
        double? AQI { get; set; }
        /// <summary>
        /// 首要污染物
        /// </summary>
        string PrimaryPollutant { get; set; }
        /// <summary>
        /// 空气质量指数类别
        /// </summary>
        string Type { get; set; }
    }
}
