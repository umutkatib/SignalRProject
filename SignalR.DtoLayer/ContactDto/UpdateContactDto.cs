namespace SignalR.DtoLayer.ContactDto
{
	public class UpdateContactDto
	{
        public int ContactID { get; set; }
        public string ContactLocation { get; set; }
        public string ContactPhone { get; set; }
        public string ContactMail { get; set; }
        public string ContactFooterTitle { get; set; }
        public string ContactFooterDescription { get; set; }
        public string ContactFooterOpenDays { get; set; }
        public string ContactFooterOpenHours { get; set; }
        public string ContactFooterOpenDaysDescription { get; set; }

    }
}
