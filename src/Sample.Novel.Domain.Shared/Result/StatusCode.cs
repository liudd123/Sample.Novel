using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sample.Novel.Domain.Shared.Result
{
    public enum StatusCode
    {
        /// <summary>
        /// 系统（函数）出现错误
        /// </summary>
        SystemError = 0,
        /// <summary>
        /// 请求成功
        /// </summary>
        Success = 200,
        /// <summary>
        /// 人为主动抛出异常
        /// </summary>
        ThrowError = 201,
        /// <summary>
        /// 数据验证未通过
        /// </summary>
        DataVerifyNoPass = 202,
        /// <summary>
        /// 用户未登录
        /// </summary>
        NoLogin = 203,
        /// <summary>
        /// 流程错误
        /// </summary>
        WorkFlow = 204,
        /// <summary>
        /// 请求Token为空
        /// </summary>
        TokenEmpty = 205,
        /// <summary>
        /// Token过期
        /// </summary>
        TokenExpire = 207,
        /// <summary>
        /// 没权限
        /// </summary>
        NoPermissions=208
    }
}
