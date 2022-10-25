using FluentValidation;
using hbb_ges.EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace hbb_ges.BusinessLayer.ValidationRules
{
    public class InfoValidator:AbstractValidator<Info>
    {
        public InfoValidator()
        {
            RuleFor(x => x.description).NotEmpty().WithMessage("İçerik alanını boş geçemezsiniz");
            RuleFor(x => x.image).NotEmpty().WithMessage("Bu alanı boş geçemezsiniz");
            RuleFor(x => x.description).MaximumLength(5000).WithMessage("İçerik alanı en fazla 5000 karakter olmalıdır");
            RuleFor(x => x.description).MinimumLength(11).WithMessage("İçerik alanı en az 11 karakter olmalıdır");
        }
    }
}
