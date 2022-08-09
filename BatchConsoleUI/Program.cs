using DataAccess.Concrete.EntityFramework;
using DataAccess.Concrete.EntityFramework.Contexts;
using Entity.Concrete.DTOs;
using Services.Concrete;

PaymentManager paymentManager = new PaymentManager(new EfUnitOfWork(new RentCarContext()));

var result = await paymentManager.GetAllByNonDeleted();
var paymentList = result.Data.Payments;


foreach (var payment in paymentList)
{
    if (payment.EODDate<DateTime.Now)
    {
        payment.ModifiedDate = DateTime.Now;
        payment.IsCancelled = true;
        await paymentManager.UpdateBatch(payment);
    }
}