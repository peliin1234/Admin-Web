using FluentValidation;
using hbb_ges.EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace hbb_ges.BusinessLayer.ValidationRules
{
    public class MessageValidator:AbstractValidator<Message>
    {
        public MessageValidator()
        {
            RuleFor(x => x.message).NotEmpty().WithMessage(" Mesaj alanını boş geçemezsiniz");
            RuleFor(x => x.subject).NotEmpty().WithMessage(" Konu alanını boş geçemezsiniz");
            RuleFor(x => x.subject).MaximumLength(100).WithMessage("Konu alanı en fazla 100 karakter olmalıdır");
            RuleFor(x => x.message).MaximumLength(1000).WithMessage("Mesaj alanı en fazla 1000 karakter olmalıdır");
            RuleFor(x => x.message).MinimumLength(10).WithMessage("Mesaj alanı en az 10 karakter olmalıdır");
            RuleFor(x => x.subject).MinimumLength(4).WithMessage("Konu alanı en az 4 karakter olmalıdır");
        }
    }
}
