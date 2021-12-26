using Entities.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.ValidationRules
{
    public class CarValidator : AbstractValidator<Car>
    {
        public CarValidator()
        {
            // Hangi nesne için validator yazacaksan buranın içine yazıyoruz
            RuleFor(c => c.Description).MinimumLength(2);
            RuleFor(c => c.BrandId).NotEmpty();
            RuleFor(c => c.Id).GreaterThan(0);
            // örneğin içecek ise birim fiyatı 10dan büyük olmalı
            RuleFor(c => c.DailyPrice).GreaterThanOrEqualTo(10).When(p => p.ModelYear == "2000");
            // örneğin olmayan bir şeyi de kendimiz yazabiliriz
            // Ozel bir mesaj vermek istersek withmessagekullanırız
            RuleFor(c => c.Description).Must(StartWithB).WithMessage("Ürünler B harfi ile başlamalı");// StartWithA bizim metodumuz
        }

        private bool StartWithB(string arg)
        {
            return arg.StartsWith("B");
        }
    }
}
