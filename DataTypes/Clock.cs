namespace WorldtreeNexus.DataTypes {
    public class Clock {
        public string[] Day = [ "SUN", "MON", "TUE", "WED", "THU", "FRI", "SAT" ];
        public int Hour = 6;
        public int Minute = 0;
        public int Weekday = 0; // 0 Sunday, 1 Monday, 2 Tuesday, 3 Wednesday, 4 Thursday, 5 Friday, 6 Saturday

        public int DaysPassed = 0;

        public bool TwelveHour = true; // True: display time like 6:00pm, False: display time as 18:00

        public void Tick() {
            Minute++;

            if (Minute >= 60) {
                Minute = 0;
                Hour++; 
            }

            if (Hour >= 24) {
                Hour = 0;
                Weekday++;
                DaysPassed++;
            }

            if (Weekday >= 7) {
                Weekday = 0;
            }
        } 

        public string GetTime() {
            if (TwelveHour) {
                bool pm = Hour >= 12;
                int adjHour = pm ? (Hour > 12 ? Hour - 12 : 12) : Hour;

                return Day[Weekday] + "  " + DaysPassed.ToString().Align(HorizontalAlignment.Left, 4) + " " + Helper.ConvertTime(Hour, Minute, TwelveHour);
            } else { 
                return Day[Weekday] + "  " + DaysPassed.ToString().Align(HorizontalAlignment.Left, 4) + "    " + Helper.ConvertTime(Hour, Minute, TwelveHour);
            }
        }
    }
}
