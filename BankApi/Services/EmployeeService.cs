using BankApi.Contracts.Employee;
using BankApi.Contracts.File;
using BankApi.Contracts.Pagination;
using BankApi.Data;
using BankApi.Errors;
using BankApi.Models;
using BankApi.Utils;
using Mapster;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace BankApi.Services
{
    public class EmployeeService(DatabaseContext database,IFileService file) : IEmployee
    {
        public async Task<Result<EmployeeRes>> AddNewEmployee(EmployeeReq req, CancellationToken ct)
        {
         Employee emp=req.Adapt<Employee>();

            if (req.image is not null)
            {
                emp.UploadedImage = await getUploadedImageMetaData(req.image, ct);
            }
          await database.Employees.AddAsync(emp);
            EmployeeRes res = emp.Adapt<EmployeeRes>();
            return await Commit()?Result.Success(res):Result.Failure<EmployeeRes>(EmployeeErrors.BadRequest);
        }

        public async Task<bool> Commit()
        {
            return await database.SaveChangesAsync() > 0;
        }

        public Task<Result> DeleteEmployee(Guid id, CancellationToken ct)
        {
            throw new NotImplementedException();
        }

        public async Task<Result<PaginatedList<EmployeeRes>>> GetAll(PaginatedReq req,CancellationToken ct)
        {
           

            IQueryable<Employee> employees =  database.Employees
                .Include(e=>e.UploadedImage);

            PaginatedList<EmployeeRes> paginatedEmps =await PaginatedList<EmployeeRes>.Create(mapToEmployeeRes(employees,ct),req.pageSize,req.pageNumber);
            
            return paginatedEmps.TotalPages > 0 ? Result.Success(paginatedEmps) :
                Result.Failure<PaginatedList<EmployeeRes>>(EmployeeErrors.NotFound);
        }
        private  IQueryable< EmployeeRes> mapToEmployeeRes(IQueryable<Employee> employees,CancellationToken ct)
        {
            IQueryable<EmployeeRes> emps = employees.Select(e => new EmployeeRes(
                    e.Id,
                    e.FName,
                    e.LName,
                    e.UserName,
                    e.Email,
                    e.Role,
                    e.Status,
                    e.Title,
                    e.Department,
                    e.UserHash,
                    e.ReportsTo,
                    e.Address,
                    e.OfficePhone,
                    e.MobilePhone,
                    e.Notes,
                    e.UploadedImage == null ? null :
                    new UploadedFileRes(
                        e.UploadedImage.ID,
                        e.UploadedImage.FileName,
                        e.UploadedImage.FileSize,
                        e.UploadedImage.ContentType,
                        e.UploadedImage.Extension
                        )

                    ));
            return emps;
        }
        public async Task<Result<EmployeeRes>> GetEmployee(Guid id, CancellationToken ct)
        {
            IQueryable<Employee>? emp = database.Employees.Where(emp=>emp.Id==id) ;
            if(emp is null)return Result.Failure<EmployeeRes>(EmployeeErrors.NotFound);
            EmployeeRes res =await mapToEmployeeRes(emp,ct).FirstAsync();
            return Result.Success(res);
        }

        public async Task<Result> UpdateEmployee(EmployeeReq req, Guid id, CancellationToken ct)
        {
            Employee? emp = await database.Employees.FindAsync(id);
            if (emp is null) return Result.Failure(EmployeeErrors.NotFound);
            req.Adapt(emp);
            if (req.image is not null)
            {
                emp.UploadedImage = await getUploadedImageMetaData(req.image, ct);
            }
            return await Commit()  ? Result.Success() : Result.Failure(EmployeeErrors.BadRequest);
        }
        private async Task<UploadedImage> getUploadedImageMetaData(IFormFile image,CancellationToken ct)
        {
            UploadedFileReq fileReq = await file.UploadFileAsync(image, ct);
            UploadedImage upImage = new UploadedImage()
            {
                ContentType = fileReq.contentType,
                //ImagePath = fileReq.ImagePath,
                FileSize = fileReq.fileSize,
                Extension = fileReq.extension,
                FileName = fileReq.fileName,
                StoredFileName = fileReq.storedFileName

            };
            return upImage;
        }
    }
}
