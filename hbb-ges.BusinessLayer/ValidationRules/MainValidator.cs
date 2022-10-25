using FluentValidation;
using hbb_ges.EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace hbb_ges.BusinessLayer.ValidationRules
{
    public class MainValidator:AbstractValidator<MainPage>
    {
        public MainValidator()
        {
            RuleFor(x => x.content).NotEmpty().WithMessage("İçerik alanını boş geçemezsiniz");
            RuleFor(x => x.image).NotEmpty().WithMessage(" Görsel alanını boş geçemezsiniz");
            RuleFor(x => x.content).MaximumLength(5000).WithMessage("İçerik alanı en fazla 5000 karakter olmalıdır");
            RuleFor(x => x.content).MinimumLength(10).WithMessage("İçerik alanı en az 10 karakter olmalıdır");
        }
    }
}
