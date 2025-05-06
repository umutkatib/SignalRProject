using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SignalR.BusinessLayer.Abstract;
using SignalR.DtoLayer.ContactDto;
using SignalR.EntityLayer.Entities;

namespace SignalRAPI.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class ContactController : ControllerBase
	{
		private readonly IContactService _contactService;
		private readonly IMapper _mapper;

		public ContactController(IContactService contactService, IMapper mapper)
		{
			_contactService = contactService;
			_mapper = mapper;
		}

		[HttpGet]
		public IActionResult ContactList()
		{
			var values = _mapper.Map<List<ResultContactDto>>(_contactService.TGetListAll());
			return Ok(values);
		}

		[HttpPost]
		public IActionResult ContactCreate(CreateContactDto createContactDto)
		{
			_contactService.TAdd(new Contact()
			{
				ContactMail = createContactDto.ContactMail,
				ContactLocation = createContactDto.ContactLocation,
				ContactPhone = createContactDto.ContactPhone,
				ContactFooterDescription = createContactDto.ContactFooterDescription
			});
			return Ok("İletişim Bilgileri Oluşturuldu");
		}

		[HttpDelete("{id}")] 
		public IActionResult ContactDelete(int id)
		{
			var value = _contactService.TGetByID(id);	
			_contactService.TDelete(value);
			return Ok("İletişim Bilgileri Silindi");
		}

		[HttpPut]
		public IActionResult ContactUpdate(UpdateContactDto updateContactDto)
		{
			_contactService.TUpdate(new Contact()
			{
				ContactID = updateContactDto.ContactID,
				ContactMail = updateContactDto.ContactMail,
				ContactPhone = updateContactDto.ContactPhone,
				ContactLocation = updateContactDto.ContactLocation,
				ContactFooterDescription = updateContactDto.ContactFooterDescription
			});
			return Ok("İletişim Bilgileri Güncellendi");
		}

		[HttpGet("{id}")]
		public IActionResult ContactGet(int id)
		{
			var value = _contactService.TGetByID(id);
			return Ok(value);
		}
	}
}
