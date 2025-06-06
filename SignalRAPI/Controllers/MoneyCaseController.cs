﻿using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SignalR.BusinessLayer.Abstract;

namespace SignalRAPI.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class MoneyCaseController : ControllerBase
	{
		private readonly IMoneyCaseService _moneyCaseService;

		public MoneyCaseController(IMoneyCaseService moneyCaseService)
		{
			_moneyCaseService = moneyCaseService;
		}

		[HttpGet]
		public IActionResult TotalMoneyCaseAmount()
		{
			return Ok(_moneyCaseService.TTotalMoneyCaseAmount());
		}
	}
}
