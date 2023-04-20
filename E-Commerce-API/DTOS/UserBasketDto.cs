using E_Commerce_API.Entities;

namespace E_Commerce_API.DTOS
{
    public class UserBasketDto
    {
        public string Id { get; set; }
        public List<BaskeItemDto> BaskeItems { get; set; } = new List<BaskeItemDto>();
    }
}
