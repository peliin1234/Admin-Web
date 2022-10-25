using FluentValidation;
using hbb_ges.EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace hbb_ges.BusinessLayer.ValidationRules
{
    public class GalleryValidator:AbstractValidator<Gallery>
    {
        public GalleryValidator()
        {
            RuleFor(x => x.Name).NotEmpty().WithMessage("Başlık alanını boş geçemezsiniz");
            RuleFor(x => x.Image).NotEmpty().WithMessage(" Görsel alanını boş geçemezsiniz");
            RuleFor(x => x.Name).MaximumLength(50).WithMessage("İçerik alanı en fazla 50 karakter olmalıdır");
            RuleFor(x => x.Name).MinimumLength(3).WithMessage("İçerik alanı en az 3 karakter olmalıdır");
        }
        
    
}
}
