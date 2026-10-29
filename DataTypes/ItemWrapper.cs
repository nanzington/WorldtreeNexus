using Newtonsoft.Json;

namespace WorldtreeNexus.DataTypes {
    public class ItemWrapper {
        public string ID = "";
        public int Quantity = 1;
        public int Charges = 1;
        public bool Noted = false; 

        public int MiscInt = 0;
        public int MiscInt2 = 0;
        public int MiscInt3 = 0;

        public List<ItemWrapper> Containing = new();
        public bool AutoAddingContainer = false;
        public AlchemyStats Alchemy = null;

        public string MiscString = "";

        [JsonIgnore]
        public Item? Library = null; 

        [JsonIgnore]
        public bool Inaccessible = false;

        public ItemWrapper() { }

        public ItemWrapper(Item wrap, bool inaccessible = false) {
            ID = wrap.ID;
            Quantity = wrap.Quantity;
             
            Charges = wrap.UseInt4; 

            Noted = wrap.Noted;

            Inaccessible = inaccessible; 

            MiscInt = wrap.UseInt;
            MiscInt2 = wrap.UseInt2;
            MiscInt3 = wrap.UseInt3;
            MiscString = wrap.MiscString;

            if (wrap.Alchemy != null) {
                Alchemy = new(wrap.Alchemy);
            }

            if (wrap.Containing.Count > 0) {
                foreach (var con in wrap.Containing) {
                    Containing.Add(new(con));
                }
            }
        }

        public ItemWrapper(string id, int qty, bool note = false, int chg = 1) {
            ID = id;
            Quantity = qty;
            Noted = note;
            Charges = chg;
        }

        public ItemWrapper(ItemWrapper other) {
            ID = other.ID;
            Quantity = other.Quantity;
            Charges = other.Charges;
            Noted = other.Noted;
            Inaccessible = other.Inaccessible;
            Library = other.Library;
             
            MiscInt = other.MiscInt;
            MiscInt2 = other.MiscInt2;
            MiscInt3 = other.MiscInt3;
            MiscString = other.MiscString;

            if (other.Alchemy != null) {
                Alchemy = new(other.Alchemy);
            }

            for (int i = 0; i < other.Containing.Count; i++) {
                Containing.Add(other.Containing[i]);
            }
        }


        public Item? GetRef() {
            if (Library == null) {
                if (GameLoop.WTN.ItemLibrary.TryGetValue(ID, out Item? lib) && lib != null) {
                    Item clone = new(lib);
                    clone.Quantity = Quantity;
                    clone.UseInt4 = Charges;

                    clone.Alchemy = Alchemy;


                    return clone;
                }
            }
            if (Library != null)
                return new(Library);
            return null;
        }

        public void TryConsume() {
            Quantity -= 1;
        }
    }
}
