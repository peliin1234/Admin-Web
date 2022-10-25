using FluentValidation;
using hbb_ges.EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace hbb_ges.BusinessLayer.ValidationRules
{
    public class ContactValidator:AbstractValidator<Contact>
    {
        public ContactValidator()
        {
            RuleFor(x => x.ContactTitle).NotEmpty().WithMessage(" Mesaj alanını boş geçemezsiniz");
            RuleFor(x => x.ContactDescription).NotEmpty().WithMessage(" Konu alanını boş geçemezsiniz");
            RuleFor(x => x.ContactTitle).MaximumLength(100).WithMessage("Konu alanı en fazla 100 karakter olmalıdır");
            RuleFor(x => x.ContactDescription).MaximumLength(1000).WithMessage("Mesaj alanı en fazla 1000 karakter olmalıdır");
            RuleFor(x => x.ContactDescription).MinimumLength(50).WithMessage("Mesaj alanı en az 50 karakter olmalıdır");
            RuleFor(x => x.ContactTitle).MinimumLength(5).WithMessage("Konu alanı en az 5 karakter olmalıdır");
        }
    }
}
