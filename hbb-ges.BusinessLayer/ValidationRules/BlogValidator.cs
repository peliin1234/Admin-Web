using FluentValidation;
using hbb_ges.EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace hbb_ges.BusinessLayer.ValidationRules
{
    public class BlogValidator:AbstractValidator<Blog>
    {
        public BlogValidator()
        {
            RuleFor(x => x.BlogTitle).NotEmpty().WithMessage("Başlık alanını boş geçemezsiniz");
            RuleFor(x => x.BlogContent).NotEmpty().WithMessage("İçerik alanını boş geçemezsiniz");
            RuleFor(x => x.BlogImage).NotEmpty().WithMessage(" Görsel alanını boş geçemezsiniz");
            RuleFor(x => x.BlogContent).MaximumLength(5000).WithMessage("İçerik alanı en fazla 5000 karakter olmalıdır");
            RuleFor(x => x.BlogContent).MinimumLength(10).WithMessage("İçerik alanı en az 10 karakter olmalıdır");
        }
    }
}
