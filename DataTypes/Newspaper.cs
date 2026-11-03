namespace WorldtreeNexus.DataTypes {
    public class Newspaper {
        public string Name = "";
        public string ID = ""; 
        public string Byline = "";
        public List<NewspaperSheet> Sheets = new(); 

        public Newspaper(string name, string id, string byline, List<NewspaperSheet> sheets) {
            Name = name;
            ID = id; 
            Byline = byline;

            Sheets = sheets;
        }
    }

    public class NewspaperSheet { 
        public List<NewspaperColumn> Columns = new();

        public NewspaperSheet(List<NewspaperColumn> columns) {
            Columns = columns;
        }
    }

    public class NewspaperColumn {
        public int Width = 36; // 109 wide area, so by default you can fit two 36-width and a 38-width on a sheet (counting the two separators)
        public List<NewspaperSection> Sections = new();

        public NewspaperColumn(int width, List<NewspaperSection> sections) {
            Width = width;
            Sections = sections;
        }
    }

    public class NewspaperSection { 
        public string Text = "";
        public int ClickLeadsToPage = -1; // If set to anything but -1, will set the newspaper view to that page. Used for sections that are blurbs for larger articles in another part of the paper

        public NewspaperSection(string text) {
            Text = text;
        }
    }
}
