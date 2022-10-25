using FluentValidation;
using hbb_ges.EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace hbb_ges.BusinessLayer.ValidationRules
{
    public class AboutValidator:AbstractValidator<About>
    {
        public AboutValidator()
        {
            RuleFor(x => x.AboutDetails).NotEmpty().WithMessage("İçerik alanını boş geçemezsiniz");
            RuleFor(x => x.AboutImage).NotEmpty().WithMessage(" Görsel alanını boş geçemezsiniz");
            RuleFor(x => x.AboutDetails).MaximumLength(5000).WithMessage("İçerik alanı en fazla 5000 karakter olmalıdır");
            RuleFor(x => x.AboutDetails).MinimumLength(50).WithMessage("İçerik alanı en az 50 karakter olmalıdır");
        }
    }
}
