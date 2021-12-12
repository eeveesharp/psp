using ClosedXML.Excel;
using Educational_Process.Domain;
using Educational_Process.Models;
using Educational_Process.Services.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Educational_Process.Services.Implementations
{
    public class StudentPerformanceService : IStudentPerformanceService
    {
        private readonly EducationalProcessContext _educationalProcessContext;
        private XLWorkbook _xLWorkbook;

        public StudentPerformanceService(EducationalProcessContext educationalProcessContext)
        {
            _educationalProcessContext = educationalProcessContext;
        }

        public void Delete(int id)
        {
            StudentPerformance studentPerformance = _educationalProcessContext.StudentPerformances.Where(contract => contract.Id == id).FirstOrDefault();
            _educationalProcessContext.StudentPerformances.Remove(studentPerformance);
            _educationalProcessContext.SaveChanges();
        }

        public void Edit(int id, StudentPerformance item)
        {
            _educationalProcessContext.StudentPerformances.Update(item);
            _educationalProcessContext.SaveChanges();
        }

        public IEnumerable<StudentPerformance> GetAll()
        {
            return _educationalProcessContext.StudentPerformances
                .Include(x => x.Student)
                .Include(x => x.Subject)
                .Include(x => x.Subject.Teacher)
                .Include(x => x.Student.Group)
                .AsNoTracking()
                .ToList();
        }

        public StudentPerformance GetById(int id)
        {
            return _educationalProcessContext.StudentPerformances
                .Include(x => x.Student)
                .Include(x => x.Subject)
                .Include(x => x.Subject.Teacher)
                .Include(x => x.Student.Group)
                .AsNoTracking()
                .Where(contract => contract.Id == id)
                .FirstOrDefault();
        }

        public void Create(StudentPerformance item)
        {
            _educationalProcessContext.StudentPerformances.Add(item);
            _educationalProcessContext.SaveChanges();
        }

        public XLWorkbook GetWorkbookBySubject(int subjectId)
        {
            var perf = GetAll();

            perf = perf.Where(x => x.Subject.Id == subjectId);

            perf = perf.OrderBy(x => x.Mark);
            FeelWorkBook(perf);

            return _xLWorkbook;
        }

        public XLWorkbook GetFullWorkbook()
        {
            var visits = GetAll();
            visits = visits.OrderBy(x => x.Student.Group.Name);
            FeelWorkBook(visits);
            return _xLWorkbook;
        }

        private void FeelWorkBook(IEnumerable<StudentPerformance> perf)
        {
            var workbook = new XLWorkbook();

            var worksheet = workbook.Worksheets.Add("Услуги");
            var currentRow = 1;

            worksheet.Cell(currentRow, 1).Value = "Группа";
            worksheet.Cell(currentRow, 2).Value = "Фамилия студента";
            worksheet.Cell(currentRow, 3).Value = "Имя студента";
            worksheet.Cell(currentRow, 4).Value = "Отчество студента";
            worksheet.Cell(currentRow, 5).Value = "Предмет";
            worksheet.Cell(currentRow, 6).Value = "Оценка";
            worksheet.Cell(currentRow, 7).Value = "Фамилия преподавателя";
            worksheet.Cell(currentRow, 8).Value = "Имя преподавателя";
            worksheet.Cell(currentRow, 9).Value = "Отчество преподавателя";

            foreach (var per in perf)
            {
                currentRow++;
                worksheet.Cell(currentRow, 1).Value = per.Student?.Group?.Name ?? "нет данных";
                worksheet.Cell(currentRow, 2).Value = per.Student?.SecondName ?? "нет данных";
                worksheet.Cell(currentRow, 3).Value = per.Student?.FirstName ?? "нет данных";
                worksheet.Cell(currentRow, 4).Value = per.Student?.ThirdName ?? "нет данных";
                worksheet.Cell(currentRow, 5).Value = per.Subject?.Name ?? "нет данных";
                worksheet.Cell(currentRow, 6).Value = per.Mark;
                worksheet.Cell(currentRow, 7).Value = per.Subject?.Teacher?.SecondName ?? "нет данных";
                worksheet.Cell(currentRow, 8).Value = per.Subject?.Teacher?.FirstName ?? "нет данных";
                worksheet.Cell(currentRow, 9).Value = per.Subject?.Teacher?.ThirdName ?? "нет данных";
            }

            _xLWorkbook = workbook;
        }
    }
}
