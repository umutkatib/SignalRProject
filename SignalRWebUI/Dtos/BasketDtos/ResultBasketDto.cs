namespace SignalRWebUI.Dtos.BasketDtos
{
    public class ResultBasketDto
    {
        public int BasketID { get; set; }
        public decimal BasketPrice { get; set; }
        public int BasketCount { get; set; }
        public decimal BasketTotalPrice { get; set; }
        public int ProductID { get; set; }
        public int MenuTableID { get; set; }
        public string BasketProductName { get; set; }
    }
}
