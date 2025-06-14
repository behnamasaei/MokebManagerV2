using DocumentFormat.OpenXml.Spreadsheet;
using IdGen;
using QRCoder;
using QuestPDF.Fluent;
using QuestPDF.Helpers;
using QuestPDF.Infrastructure;
using System.Drawing;
using Color = System.Drawing.Color;


namespace BarcodeGenerator;

public class Program
{
    public static void Main()
    {
        QuestPDF.Settings.License = LicenseType.Community;
        List<long> barcodes = new();

        Document.Create(container =>
        {
            container.Page(page =>
            {
                page.Margin(20);
                page.Size(PageSizes.A4.Portrait());
                page.Content()
                    .Table(table =>
                    {
                        table.ColumnsDefinition(columns =>
                        {
                            for (int i = 0; i < 5; i++)
                            {
                                columns.RelativeColumn();
                            }


                        });
                        var generator = new IdGenerator(0);
                        for (int i = 0; i < 30; i++)
                        {
                            var barcode = generator.CreateId();
                            while (barcodes.Any(x => x == barcode))
                            {
                                barcode = generator.CreateId();
                            }


                            table.Cell().Element(CellStyle).Column(column =>
                            {
                                column.Spacing(0);
                                column.Item().Padding(0);
                                column.Item().Text("سامانه خادم یار").LineHeight(2f).FontSize(10).FontFamily("IRANSans").AlignCenter();
                                column.Item().Image(BarcodeGenerator(barcode.ToString()));
                                column.Item().Text(barcode.ToString()).LineHeight(2f).FontSize(8).AlignCenter();
                            });
                        }



                        static IContainer CellStyle(IContainer container) =>
                                               container
                                                   .Border(1)
                                                   .Padding(7)
                                                   .AlignCenter()
                                                   .PreventPageBreak()
                                                   .AlignMiddle();
                    });
            });
        }).GeneratePdf("3.pdf");
    }

    public static byte[] BarcodeGenerator(string text)
    {
        using (QRCodeGenerator qrGenerator = new QRCodeGenerator())
        using (QRCodeData qrCodeData = qrGenerator.CreateQrCode(text, QRCodeGenerator.ECCLevel.Q))
        using (PngByteQRCode qrCode = new PngByteQRCode(qrCodeData))
        {

            int pixelsPerModule = 10;
            Color darkColor = Color.Black;
            Color lightColor = Color.White;
            bool drawQuietZones = false; // ⬅️ این گزینه باعث حذف فضای سفید می‌شود

            return qrCode.GetGraphic(pixelsPerModule, darkColor, lightColor, drawQuietZones);
        }
    }
}






