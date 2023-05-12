using System.Runtime.Serialization;

namespace E_Commerce_API.Entities.Order
{
    public enum OrderStatus
    {
        [EnumMember(Value ="Pending")]
        Pending,

        [EnumMember(Value = "Payment Received")]
        PaymentReceived,

        [EnumMember(Value = "Payment Faild")]
        PaymentFaild,

    }
}
