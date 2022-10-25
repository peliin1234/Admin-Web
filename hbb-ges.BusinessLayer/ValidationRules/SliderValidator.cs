using FluentValidation;
using hbb_ges.EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace hbb_ges.BusinessLayer.ValidationRules
{
    public class SliderValidator:AbstractValidator<Slider>
    {
        public SliderValidator()
        {
            RuleFor(x => x.Title).NotEmpty().WithMessage("Başlık alanını boş geçemezsiniz");
            RuleFor(x => x.SubTitle).NotEmpty().WithMessage("Başlık alanını boş geçemezsiniz");
            RuleFor(x => x.Image).NotEmpty().WithMessage(" Görsel alanını boş geçemezsiniz");
            RuleFor(x => x.Title).MaximumLength(100).WithMessage("Başlık alanı en fazla 5000 karakter olmalıdır");
        }
    }
}
