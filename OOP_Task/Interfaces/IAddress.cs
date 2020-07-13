
namespace OOP_Task.Interfaces
{
    interface IAddress
    {
        string AddressCountry { get; set; }

        string AddressCity { get; set; }

        string AddressStreet { get; set; }

        int AddressStreetNumber { get; set; }
    }
}
