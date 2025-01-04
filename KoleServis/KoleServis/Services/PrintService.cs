using KoleServis.Core;
using KoleServis.MVVM.Models;
using KoleServis.Services;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Media.Imaging;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Security.Cryptography;
using KoleServis.MVVM.View;
using System.Drawing.Printing;
using System.Windows.Forms;
using System.Windows.Controls;
using static MaterialDesignThemes.Wpf.Theme.ToolBar;
using System.Windows.Documents;
using System.Windows.Media;
using System.Globalization;
using KoleServis.MVVM.ViewModel;
using System.Windows.Shapes;
using System.Windows.Controls.Primitives;
using static System.Runtime.InteropServices.JavaScript.JSType;
using Microsoft.EntityFrameworkCore.Migrations.Operations;

namespace KoleServis.Services
{
    public class PrintService
    {
        public  FlowDocument CreateFlowDocument(ObservableCollection<ItemComponentViewModel> ItemsBill,string CustomerName,Racun bill,string Number,string Date,string PriceOverall)
        {
            FlowDocument flowDocument = new FlowDocument
            {
                PageWidth = 794, 
                PagePadding = new Thickness(30),
                ColumnWidth = 694 
            };
            Table table = new Table();
            table.Columns.Add(new TableColumn { Width = new GridLength(2, GridUnitType.Star) }); 
            table.Columns.Add(new TableColumn { Width = new GridLength(3, GridUnitType.Star) });
            table.RowGroups.Add(CreateHeader());
            flowDocument.Blocks.Add(table);
            
            
            BlockUIContainer lineContainer = new BlockUIContainer(CreateLine());
            flowDocument.Blocks.Add(lineContainer);

            
            table = new Table();
            table.Columns.Add(new TableColumn { Width = new GridLength(1.5, GridUnitType.Star) }); 
            table.Columns.Add(new TableColumn { Width = new GridLength(1, GridUnitType.Star) }); 
            table.Columns.Add(new TableColumn { Width = new GridLength(1, GridUnitType.Star) }); 
            table.Columns.Add(new TableColumn { Width = new GridLength(1, GridUnitType.Star) });
            table.RowGroups.Add(CreateBillData(CustomerName,bill,Number,Date));
            flowDocument.Blocks.Add(table);

            
            table = new Table
            {
                CellSpacing = 5 
            };
            table.Columns.Add(new TableColumn { Width = new GridLength(3, GridUnitType.Star) }); 
            table.Columns.Add(new TableColumn { Width = new GridLength(0.5, GridUnitType.Star) }); 
            table.Columns.Add(new TableColumn { Width = new GridLength(1, GridUnitType.Star) }); 
            table.Columns.Add(new TableColumn { Width = new GridLength(1, GridUnitType.Star) }); 
            table.Columns.Add(new TableColumn { Width = new GridLength(2, GridUnitType.Star) }); 
            TableRowGroup headerGroup = new TableRowGroup();
            TableRow headerRow = new TableRow();
            headerGroup.Rows.Add(CreateHeaderRow(headerRow));
            table.RowGroups.Add(headerGroup);
            table.RowGroups.Add(InsertData(ItemsBill));
            flowDocument.Blocks.Add(table);


            flowDocument.Blocks.Add(new Paragraph()); 
            flowDocument.Blocks.Add(new Paragraph());
            flowDocument.Blocks.Add(new Paragraph());


            table = new Table();
            table.Columns.Add(new TableColumn { Width = new GridLength(3, GridUnitType.Star) });
            table.Columns.Add(new TableColumn { Width = new GridLength(0.5, GridUnitType.Star) });
            table.RowGroups.Add(CreatePriceOverall(PriceOverall));
            flowDocument.Blocks.Add(table);

            flowDocument.Blocks.Add(new Paragraph());
            flowDocument.Blocks.Add(new Paragraph());
            flowDocument.Blocks.Add(new Paragraph(new Run("Napomena: Ovaj račun nije u sistemu PDV-a.")));
            flowDocument.Blocks.Add(new Paragraph());
            flowDocument.Blocks.Add(new Paragraph());

            
            table=new Table();
            table.Columns.Add(new TableColumn { Width = new GridLength(1, GridUnitType.Star) });
            table.Columns.Add(new TableColumn { Width = new GridLength(1, GridUnitType.Star) });
            table.Columns.Add(new TableColumn { Width = new GridLength(1, GridUnitType.Star) });
            table.RowGroups.Add(CreateFooter());
            flowDocument.Blocks.Add(table);

            return flowDocument;
        }

        public TableRowGroup CreateHeader()
        {
            TableRowGroup rowGroup = new TableRowGroup();
            TableRow tmpRow = new TableRow();
            tmpRow.Cells.Add(new TableCell(new Paragraph(new Run("KOLE SERVIS s.p")) { FontWeight = FontWeights.Bold }));
            rowGroup.Rows.Add(tmpRow);
            tmpRow = new TableRow();
            tmpRow.Cells.Add(new TableCell(new Paragraph(new Run("JIB: 4509143640005"))));
            rowGroup.Rows.Add(tmpRow);
            tmpRow = new TableRow();
            tmpRow.Cells.Add(new TableCell(new Paragraph(new Run("Ilije Grbića 6"))));
            rowGroup.Rows.Add(tmpRow);
            tmpRow = new TableRow();
            tmpRow.Cells.Add(new TableCell(new Paragraph(new Run("78000 Banja Luka"))));
            tmpRow.Cells.Add(new TableCell(new Paragraph(new Run("Žiro Račun:"))));
            rowGroup.Rows.Add(tmpRow);
            tmpRow = new TableRow();
            tmpRow.Cells.Add(new TableCell(new Paragraph(new Run("Tel/Fax: 051/213-595"))));
            tmpRow.Cells.Add(new TableCell(new Paragraph(new Run("Žiro Račun: 194-106-84768001-69")) { FontWeight = FontWeights.Bold }));
            rowGroup.Rows.Add(tmpRow);
            return rowGroup;
        }

        public TableRow CreateHeaderRow(TableRow headerRow)
        {
            headerRow.Cells.Add(new TableCell(new Paragraph(new Run("Naziv")))
            {
                FontWeight = FontWeights.Bold,
                BorderBrush = Brushes.Black,
                BorderThickness = new Thickness(0, 0, 0, 1),
                Padding = new Thickness(5)
            });
            headerRow.Cells.Add(new TableCell(new Paragraph(new Run("JM")) { TextAlignment = TextAlignment.Right })
            {
                FontWeight = FontWeights.Bold,
                BorderBrush = Brushes.Black,
                BorderThickness = new Thickness(0, 0, 0, 1),
                Padding = new Thickness(5)
            });
            headerRow.Cells.Add(new TableCell(new Paragraph(new Run("Količina")) { TextAlignment = TextAlignment.Right })
            {
                FontWeight = FontWeights.Bold,
                BorderBrush = Brushes.Black,
                BorderThickness = new Thickness(0, 0, 0, 1),
                Padding = new Thickness(5)
            });
            headerRow.Cells.Add(new TableCell(new Paragraph(new Run("Cijena")) { TextAlignment = TextAlignment.Right })
            {
                FontWeight = FontWeights.Bold,
                BorderBrush = Brushes.Black,
                BorderThickness = new Thickness(0, 0, 0, 1),
                Padding = new Thickness(5)
            });
            headerRow.Cells.Add(new TableCell(new Paragraph(new Run("Vrijednost")) { TextAlignment = TextAlignment.Right })
            {
                FontWeight = FontWeights.Bold,
                BorderBrush = Brushes.Black,
                BorderThickness = new Thickness(0, 0, 0, 1),
                Padding = new Thickness(5)
            });
            return headerRow;
        }

        public Line CreateLine()
        {
            Line horizontalLine = new Line
            {
                X1 = 0,               
                X2 = 1000,           
                Y1 = 0,               
                Y2 = 0,              
                Stroke = Brushes.Black,
                StrokeThickness = 5     
            };
            return horizontalLine;
        }
        public TableRowGroup CreateBillData(string CustomerName, Racun bill, string Number, string Date)
        {
            TableRowGroup rowGroup = new TableRowGroup();
            TableRow rowtmp = new TableRow();

            TableCell leftCell = new TableCell();
            TextBlock textBlock = new TextBlock(new Run(CustomerName))
            {
                TextWrapping = TextWrapping.Wrap, 
                HorizontalAlignment = HorizontalAlignment.Left, 
                VerticalAlignment = VerticalAlignment.Center 
            };

            BlockUIContainer blockUIContainer = new BlockUIContainer(textBlock);
            leftCell.Blocks.Add(blockUIContainer);

            leftCell.BorderBrush = Brushes.Black;
            leftCell.BorderThickness = new Thickness(1);


            rowtmp.Cells.Add(leftCell);

            rowtmp.Cells.Add(new TableCell());

            TableCell rightCell = new TableCell();
            StackPanel stackPanel = new StackPanel();
            stackPanel.Orientation = Orientation.Vertical;

            stackPanel.Children.Add(new TextBlock(new Run("Račun br:")) { HorizontalAlignment = HorizontalAlignment.Left, FontWeight = FontWeights.Bold });
            stackPanel.Children.Add(new TextBlock(new Run("Banja Luka, datum:")) { HorizontalAlignment = HorizontalAlignment.Left });
            stackPanel.Children.Add(new TextBlock(new Run("Valuta:")) { HorizontalAlignment = HorizontalAlignment.Left });
            stackPanel.Children.Add(new TextBlock(new Run("Datum plaćanja")) { HorizontalAlignment = HorizontalAlignment.Left });

            rightCell.Blocks.Add(new BlockUIContainer(stackPanel));
            rowtmp.Cells.Add(rightCell);

            TableCell thirdCell = new TableCell();
            stackPanel = new StackPanel();
            stackPanel.Orientation = Orientation.Vertical;

            stackPanel.Children.Add(new TextBlock(new Run(Number)) { HorizontalAlignment = HorizontalAlignment.Left, FontWeight = FontWeights.Bold });
            stackPanel.Children.Add(new TextBlock(new Run(Date)) { HorizontalAlignment = HorizontalAlignment.Left });
            stackPanel.Children.Add(new TextBlock(new Run("7")) { HorizontalAlignment = HorizontalAlignment.Left });
            stackPanel.Children.Add(new TextBlock(new Run("")) { HorizontalAlignment = HorizontalAlignment.Left });

            thirdCell.Blocks.Add(new BlockUIContainer(stackPanel));
            rowtmp.Cells.Add(thirdCell);


            rowGroup.Rows.Add(rowtmp);
            return rowGroup;
        }

        public TableRowGroup InsertData(ObservableCollection<ItemComponentViewModel> ItemsBill)
        {
            TableRowGroup bodyGroup = new TableRowGroup();

            foreach (var item in ItemsBill)
            {
                TableRow row = new TableRow();


                row.Cells.Add(new TableCell(new Paragraph(new Run(item.Naziv))));
                row.Cells.Add(new TableCell(new Paragraph(new Run("kom")) { TextAlignment = TextAlignment.Right }));
                row.Cells.Add(new TableCell(new Paragraph(new Run(item.Kolicina.ToString())) { TextAlignment = TextAlignment.Right }));
                row.Cells.Add(new TableCell(new Paragraph(new Run(item.Cijena)) { TextAlignment = TextAlignment.Right }));
                row.Cells.Add(new TableCell(new Paragraph(new Run(item.UkupnaCijena.ToString("F2"))) { TextAlignment = TextAlignment.Right }));



                bodyGroup.Rows.Add(row);
            }
            return bodyGroup;
        }

        public TableRowGroup CreatePriceOverall(string PriceOverall)
        {

            TableRowGroup tableRowGroup = new TableRowGroup();
            TableRow tableRow = new TableRow();
            tableRow.Cells.Add(new TableCell(new Paragraph(new Run("Ukupno za naplatu:")))
            {
                FontWeight = FontWeights.Bold,
                BorderBrush = Brushes.Black,
                BorderThickness = new Thickness(1, 1, 1, 1),
                Padding = new Thickness(5),
                TextAlignment = TextAlignment.Right
            });
            tableRow.Cells.Add(new TableCell(new Paragraph(new Run(PriceOverall)))
            {
                FontWeight = FontWeights.Bold,
                BorderBrush = Brushes.Black,
                BorderThickness = new Thickness(1, 1, 1, 1),
                Padding = new Thickness(5),
                TextAlignment = TextAlignment.Right
            });
            tableRowGroup.Rows.Add(tableRow);
            return tableRowGroup;
        }

        public TableRowGroup CreateFooter()
        {
            TableRowGroup tableRowGroup = new TableRowGroup();
            TableRow tableRow = new TableRow();
            tableRow.Cells.Add(new TableCell(new Paragraph(new Run()))
            {
                FontWeight = FontWeights.Bold,
                BorderBrush = Brushes.Black,
                BorderThickness = new Thickness(0,0, 0, 1),
                Padding = new Thickness(5),
                TextAlignment = TextAlignment.Right
            });
            tableRow.Cells.Add(new TableCell(new Paragraph(new Run("MP")))
            {
                FontWeight = FontWeights.Bold,
                BorderBrush = Brushes.Black,
                Padding = new Thickness(5),
                TextAlignment = TextAlignment.Center
            });
            tableRow.Cells.Add(new TableCell(new Paragraph(new Run()))
            {
                FontWeight = FontWeights.Bold,
                BorderBrush = Brushes.Black,
                BorderThickness = new Thickness(0, 0, 0, 1),
                Padding = new Thickness(5),
                TextAlignment = TextAlignment.Right
            });
            tableRowGroup.Rows.Add(tableRow);
            return tableRowGroup;
        }

    }
}
