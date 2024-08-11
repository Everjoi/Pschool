using FluentValidation;


namespace Pschool.Application.CQRS.ParentFolder.Queries.GetParentWithPagination
{
    public class GetParentsWithPaginationValidator : AbstractValidator<GetParentWithPaginationQuery>
    {
        public GetParentsWithPaginationValidator()
        {
            RuleFor(x => x.PageNumber)
            .GreaterThanOrEqualTo(1)
            .WithMessage("PageNumber at least greater than or equal to 1.");

            RuleFor(x => x.PageSize)
                .GreaterThanOrEqualTo(1)
                .WithMessage("PageSize at least greater than or equal to 1.");
        }
    }
}
