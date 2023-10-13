using Volo.Abp.Application.Dtos;

namespace Sample.Novel.Application.Contracts.Dtos.Author
{
    /// <summary>
    /// 作者
    /// </summary>
    public class AuthorDto : EntityDto<Guid>
    {
        /// <summary>
        /// 姓名
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// 描述
        /// </summary>
        public string Description { get; set; }
    }
}
