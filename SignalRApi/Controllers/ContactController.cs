using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SignalR.BusinessLayer.Abstract;
using SignalR.DTOLayer.CategoryDto;
using SignalR.DTOLayer.ContactDto;
using SignalR.EntityLayer.Entities;

namespace SignalRApi.Controllers
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
                ContactLocation = createContactDto.ContactLocation,
                ContactFooterDescription = createContactDto.ContactFooterDescription,
                ContactMail = createContactDto.ContactMail,
                ContactPhone = createContactDto.ContactPhone
            });
            return Ok("İletişim Bilgisi Başarılı Bir Şekilde Eklendi");
        }

        [HttpDelete]
        public IActionResult ContactDelete(int id)
        {
            var value = _contactService.TGetByID(id);
            _contactService.TDelete(value);
            return Ok("İletişim Bilgisi Başarılı Bir Şekilde Silindi");
        }

        [HttpPut]
        public IActionResult ContactUpdate(UpdateContactDto updateContactDto)
        {
            _contactService.TUpdate(new Contact()
            {
                ContactLocation = updateContactDto.ContactLocation,
                ContactFooterDescription = updateContactDto.ContactFooterDescription,
                ContactMail = updateContactDto.ContactMail,
                ContactPhone = updateContactDto.ContactPhone,
                ContactID = updateContactDto.ContactID
            });
            return Ok("İletişim Bilgisi Başarılı Bir Şekilde Güncellendi");
        }

        [HttpGet("GetContact")]
        public IActionResult CategoryGet(int id)
        {
            var value = _contactService.TGetByID(id);
            return Ok(value);
        }
    }
}
