﻿using Microsoft.AspNetCore.Mvc;
using Sample.Novel.Application.Contracts.Dtos;
using Sample.Novel.Application.Contracts.Interfaces;
using Volo.Abp.Application.Dtos;
using Volo.Abp.AspNetCore.Mvc;

namespace Sample.Novel.HttpApi.Host.Controllers
{
    [ControllerName("Book(书籍)")]
    [Route("api/[controller]/[action]")]
    public class BookController : AbpControllerBase, IBookAppService
    {
        private readonly IBookAppService bookAppService;

        public BookController(IBookAppService bookAppService)
        {
            this.bookAppService = bookAppService;
        }
        /// <summary>
        ///创建书籍
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task CreateBookAsync(CreateBookInput input)
        {
            await bookAppService.CreateBookAsync(input);
        }
        /// <summary>
        /// 根据id获取书籍的详情
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet]
        public async Task<BookDto> GetBookAsync(Guid id)
        {
            return await bookAppService.GetBookAsync(id);
        }
        /// <summary>
        /// 分页查询
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        [HttpGet]
        public async Task<PagedResultDto<BookDto>> GetBookListAsnyc(PagedAndSortedResultRequestDto input)
        {
            return await bookAppService.GetBookListAsnyc(input);
        }
    }
}
