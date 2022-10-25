using FluentValidation;
using hbb_ges.EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace hbb_ges.BusinessLayer.ValidationRules
{
    public class OtherCompanyValidator:AbstractValidator<OtherCompany>
    {
        public OtherCompanyValidator()
        {
            RuleFor(x => x.Name).NotEmpty().WithMessage("Ad alanını boş geçemezsiniz");
            RuleFor(x => x.Link).NotEmpty().WithMessage("Bu alanı boş geçemezsiniz");
            RuleFor(x => x.Name).MaximumLength(500).WithMessage("Ad alanı en fazla 500 karakter olmalıdır");
            RuleFor(x => x.Name).MinimumLength(5).WithMessage("Ad alanı en az 5 karakter olmalıdır");
        }
    }
}
