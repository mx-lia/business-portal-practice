using Application.Common.Interfaces;
using iTextSharp.text;
using iTextSharp.text.pdf;
using MediatR;
using System.IO;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Application.SalaryApi.Commands
{
    public class GetPdfFileCommand : IRequest
    {
        public int frontendMinSalary { get; set; }
        public int frontendMaxSalary { get; set; }
        public int backendMinSalary { get; set; }
        public int backendMaxSalary { get; set; }
        public int experience { get; set; }
        public int function { get; set; }
        public int region { get; set; }
        public bool isLead { get; set; }
    }
    public class GetPdfFileCommandHandler : AsyncRequestHandler<GetPdfFileCommand>
    {
        private readonly IDbContext _dbContext;
        public GetPdfFileCommandHandler(IDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        async protected override Task Handle(GetPdfFileCommand request, CancellationToken cancellationToken)
        {
            Document document = new Document();
            PdfWriter writer = PdfWriter.GetInstance(document,
             new FileStream("result.pdf", FileMode.Create)
             );

            document.Open();
            Paragraph Header = new Paragraph(@"Salary pdf");
            Header.Alignment = Element.ALIGN_CENTER;
            document.Add(Header);
            document.Add(new Paragraph(Chunk.NEWLINE));

            PdfPTable table = new PdfPTable(2);

            PdfPCell cell = new PdfPCell();
            Paragraph text = new Paragraph(@"Input data");
            text.Alignment = Element.ALIGN_CENTER;
            cell.AddElement(text);
            cell.BorderWidth = 1;
            cell.Colspan = 2;
            table.AddCell(cell);

            cell = new PdfPCell();
            text = new Paragraph(@"Function");
            text.Alignment = Element.ALIGN_CENTER;
            cell.AddElement(text);
            cell.BorderWidth = 1;
            table.AddCell(cell);

            var function = _dbContext.Functions.FirstOrDefault(item => item.Id == request.function);
            cell = new PdfPCell();
            text = new Paragraph(function.Name);
            text.Alignment = Element.ALIGN_CENTER;
            cell.AddElement(text);
            cell.BorderWidth = 1;
            table.AddCell(cell);

            cell = new PdfPCell();
            text = new Paragraph(@"Region");
            text.Alignment = Element.ALIGN_CENTER;
            cell.AddElement(text);
            cell.BorderWidth = 1;
            table.AddCell(cell);

            var region = _dbContext.Regions.FirstOrDefault(item => item.Id == request.region);
            cell = new PdfPCell();
            text = new Paragraph(region.Name);
            text.Alignment = Element.ALIGN_CENTER;
            cell.AddElement(text);
            cell.BorderWidth = 1;
            table.AddCell(cell);

            cell = new PdfPCell();
            text = new Paragraph(@"Experience");
            text.Alignment = Element.ALIGN_CENTER;
            cell.AddElement(text);
            cell.BorderWidth = 1;
            table.AddCell(cell);

            cell = new PdfPCell();
            text = new Paragraph(request.experience.ToString());
            text.Alignment = Element.ALIGN_CENTER;
            cell.AddElement(text);
            cell.BorderWidth = 1;
            table.AddCell(cell);

            cell = new PdfPCell();
            text = new Paragraph(@"IsLead");
            text.Alignment = Element.ALIGN_CENTER;
            cell.AddElement(text);
            cell.BorderWidth = 1;
            table.AddCell(cell);

            cell = new PdfPCell();
            text = new Paragraph(request.isLead.ToString());
            text.Alignment = Element.ALIGN_CENTER;
            cell.AddElement(text);
            cell.BorderWidth = 1;
            table.AddCell(cell);

            cell = new PdfPCell();
            text = new Paragraph(@"Output data");
            text.Alignment = Element.ALIGN_CENTER;
            cell.AddElement(text);
            cell.BorderWidth = 1;
            cell.Colspan = 2;
            table.AddCell(cell);

            cell = new PdfPCell();
            text = new Paragraph(@"Frontend min salary");
            text.Alignment = Element.ALIGN_CENTER;
            cell.AddElement(text);
            cell.BorderWidth = 1;
            table.AddCell(cell);

            cell = new PdfPCell();
            text = new Paragraph(request.frontendMinSalary.ToString());
            text.Alignment = Element.ALIGN_CENTER;
            cell.AddElement(text);
            cell.BorderWidth = 1;
            table.AddCell(cell);

            cell = new PdfPCell();
            text = new Paragraph(@"Backend min salary");
            text.Alignment = Element.ALIGN_CENTER;
            cell.AddElement(text);
            cell.BorderWidth = 1;
            table.AddCell(cell);

            cell = new PdfPCell();
            text = new Paragraph(request.backendMinSalary.ToString());
            text.Alignment = Element.ALIGN_CENTER;
            cell.AddElement(text);
            cell.BorderWidth = 1;
            table.AddCell(cell);

            cell = new PdfPCell();
            text = new Paragraph(@"Frontend max salary");
            text.Alignment = Element.ALIGN_CENTER;
            cell.AddElement(text);
            cell.BorderWidth = 1;
            table.AddCell(cell);

            cell = new PdfPCell();
            text = new Paragraph(request.frontendMaxSalary.ToString());
            text.Alignment = Element.ALIGN_CENTER;
            cell.AddElement(text);
            cell.BorderWidth = 1;
            table.AddCell(cell);

            cell = new PdfPCell();
            text = new Paragraph(@"Backend max salary");
            text.Alignment = Element.ALIGN_CENTER;
            cell.AddElement(text);
            cell.BorderWidth = 1;
            table.AddCell(cell);

            cell = new PdfPCell();
            text = new Paragraph(request.backendMaxSalary.ToString());
            text.Alignment = Element.ALIGN_CENTER;
            cell.AddElement(text);
            cell.BorderWidth = 1;
            table.AddCell(cell);

            document.Add(table);

            document.Close();
            writer.Close();
        }
    }
}
