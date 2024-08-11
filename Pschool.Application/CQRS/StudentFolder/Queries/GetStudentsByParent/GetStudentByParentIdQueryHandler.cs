using AutoMapper;
using MediatR;
using Pschool.Application.DTOs;
using Pschool.Application.Interfaces.Repository;
using Pschool.Domain.Entities;
using Pschool.Shared.Results;


namespace Pschool.Application.CQRS.StudentFolder.Queries.GetStudentsByParent
{
    public class GetStudentByParentIdQueryHandler : IRequestHandler<GetStudentByParentIdQuery, Result<List<StudentDto>>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public GetStudentByParentIdQueryHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        //TODO: use StudentRepository
        public async Task<Result<List<StudentDto>>> Handle(GetStudentByParentIdQuery query, CancellationToken cancellationToken)
        {
            var entity = await _unitOfWork.Repository<Student>().GetAllAsync();
            var studentById = entity.Where(x=>x.ParentId == query.ParentId).ToList();

            var stundets = _mapper.Map<List<StudentDto>>(studentById);
            return await Result<List<StudentDto>>.SuccessAsync(stundets);
        }

    }
}
