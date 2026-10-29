using GoRogue.GameFramework;
using WorldtreeNexus.DataTypes;
using WorldtreeNexus.HardcodedData;

namespace WorldtreeNexus.Hardcodes {
    public static class ItemsAlchemy {
        public static void InitItems(Dictionary<string, Item> ItemLibrary) {
            List<Item> itemsToAdd = new();

            itemsToAdd.Add(new Item("Alchemist's loupe", "(U)se on items to identify their alchemical values.", "alchemyLoupe", Color.Goldenrod, 1000));
            itemsToAdd.Add(new Item("Alchemist's retort", "(U)se on a mixture to increase Red and decrease Black by one each.", "alchemyRetort", Color.Crimson, 1000));
            itemsToAdd.Add(new Item("Alchemist's alembic", "(U)se on a mixture to increase Black and decrease Yellow by one each.", "alchemyAlembic", Color.DimGray, 1000));
            itemsToAdd.Add(new Item("Alchemist's crucible", "(U)se on a mixture to increase Yellow and decrease White by one each.", "alchemyCrucible", Color.Yellow, 1000));
            itemsToAdd.Add(new Item("Alchemist's aludel", "(U)se on a mixture to increase White and decrease Red by one each.", "alchemyAludel", Color.White, 1000));
            itemsToAdd.Add(new Item("Alchemist's calcinator", "(U)se on a mixture to move all colors one unit towards neutral.", "alchemyCalcinator", Color.Gray, 1000));
            itemsToAdd.Add(new Item("Alchemist's swizzler", "(U)se on a mixture to average all colors, rounded to zero, maintaining polarity, with neutral becoming positive.", "alchemySwizzler", Color.Goldenrod, 1000));
            itemsToAdd.Add(new Item("Alchemist's agitator", "(U)se on a mixture to shift all colors right one slot (Red -> Black -> Yellow -> White -> Red).", "alchemyAgitator", Color.Gray, 1000) { UseString = "Transform", UseString2 = "alchemyDeagitator"});
            itemsToAdd.Add(new Item("Alchemist's deagitator", "(U)se on a mixture to shift all colors left one slot (Red <- Black <- Yellow <- White <- Red).", "alchemyDeagitator", Color.Gray, 1000) { UseString = "Transform", UseString2 = "alchemyAgitator"});
            itemsToAdd.Add(new Item("Alchemist's inverter", "(U)se on a mixture to invert polarity of all colors.", "alchemyInverter", Color.Gray, 1000));
            itemsToAdd.Add(new Item("Alchemist's brazier", "(U)se on a mixture to finish it into a potion.", "alchemyBrazier", Color.Goldenrod, 10)); 
            itemsToAdd.Add(new Item("Alchemical mixture", "An in-progress mixture. Use a loupe to identify current status.", "alchemyMixture", Color.DarkSeaGreen, 0) { Alchemy = new() }); 
            itemsToAdd.Add(new Item("Vial of alchemical waste", "A vial of useless alchemical waste. At least the vial can be salvaged.", "alchemyFailure", Color.DimGray, 0) { UseString = "Transform", UseString2 = "vialEmpty" });
            itemsToAdd.Add(new Item("Pestle and mortar", "I can grind things for potions in this.", "pestleMortar", Color.White, 50));
            
            itemsToAdd.Add(new Item("Intro to Alchemy", "A booklet talking about alchemy, tools of the trade, and some common ingredients.", "alchemyBooklet", Color.SaddleBrown, 1) { ConsumedOnUse = false, UseString = "Book", UseString2 = "alchemyBooklet" });
            itemsToAdd.Add(new Item("Recipe (Attack potion)", "One of many ways to create an attack potion.", "alchemyRecipeAttack", Color.Khaki, 1) { ConsumedOnUse = false, UseString = "Book", UseString2 = "alchemyRecipeAttack" });
            
            
            itemsToAdd.Add(new Item("Ignis prima essentia", "The essence of fire. Used in Alchemy.", "essenceRedUp", Color.Red, 1000) { Alchemy = new(1, 0, 0, 0, 1) });  
            itemsToAdd.Add(new Item("Ignis ultima essentia", "The essence of un-fire. Used in Alchemy.", "essenceRedDown", Color.Crimson, 1000) { Alchemy = new(-1, 0, 0, 0, 1) });  
            itemsToAdd.Add(new Item("Nox prima essentia", "The essence of night. Used in Alchemy.", "essenceBlackUp", Color.Gray, 1000) { Alchemy = new(0, 1, 0, 0, 1) });  
            itemsToAdd.Add(new Item("Nox ultima essentia", "The essence of un-night. Used in Alchemy.", "essenceBlackDown", Color.DimGray, 1000) { Alchemy = new(0, -1, 0, 0, 1) });
            itemsToAdd.Add(new Item("Lux prima essentia", "The essence of light. Used in Alchemy.", "essenceYellowUp", Color.Yellow, 1000) { Alchemy = new(0, 0, 1, 0, 1) });  
            itemsToAdd.Add(new Item("Lux ultima essentia", "The essence of un-light. Used in Alchemy.", "essenceYellowDown", Color.Goldenrod, 1000) { Alchemy = new(0, 0, -1, 0, 1) });
            itemsToAdd.Add(new Item("Gelus prima essentia", "The essence of frost. Used in Alchemy.", "essenceWhiteUp", Color.White, 1000) { Alchemy = new(0, 0, 0, 1, 1) });  
            itemsToAdd.Add(new Item("Gelus ultima essentia", "The essence of un-frost. Used in Alchemy.", "essenceWhiteDown", Color.AntiqueWhite, 1000) { Alchemy = new(0, 0, 0, -1, 1) });      

            itemsToAdd.Add(new Item("Eye of cuy", "A basic Alchemy ingredient and only moderately gross.", "eyeCuy", 255, 255, 255, 25) { Alchemy = new(4, 4, -8, 6, 1) }); 
            itemsToAdd.Add(new Item("Unicorn horn dust", "Finely ground horn of Unicorn.", "unicornHornGround", Color.SandyBrown, 25) { Alchemy = new(6, -8, 2, -6, 1) });
            itemsToAdd.Add(new Item("Ground bones", "Bones, ground to dust.", "bonesRegularGround", Color.White, 25) { Alchemy = new(6, -6, 6, -4, 1) });
            
            itemsToAdd.Add(new Item("Vial", "A glass vial, currently empty.", "vialEmpty", 200, 200, 200, 2) { colA = 150 });
            itemsToAdd.Add(new Item("Vial of water", "A glass vial full of water.", "vialWater", 14, 129, 205, 2) { colA = 150 }); 
            itemsToAdd.Add(new Item("Empty vial pack", "A pack containing 100 empty vials.", "vialEmptyPack", Color.SandyBrown, 200) { UseString = "ItemPack", UseString2 = "vialEmpty", UseInt = 100});
            itemsToAdd.Add(new Item("Water-filled vial pack", "A pack containing 100 vials of water.", "vialWaterPack", Color.SandyBrown, 200) { UseString = "ItemPack", UseString2 = "vialWater", UseInt = 100});
            itemsToAdd.Add(new Item("Eye of cuy pack", "A pack containing 100 cuy eyes.", "eyeCuyPack", Color.SandyBrown, 300) { UseString = "ItemPack", UseString2 = "eyeCuy", UseInt = 100});
             
            itemsToAdd.Add(new Item("Attack potion", "Temporarily boosts your Attack level by 5.", "potionAttack", 0, 255, 255, 5) { UsesCharges = true, UseString = "Potion", UseInt4 = 3, ItemReturned = "vialEmpty", Potion = new() { new("Attack", 5) } });
            itemsToAdd.Add(new Item("Strength potion", "Temporarily boosts your Strength level by 5.", "potionStrength", Color.Yellow, 5) { UsesCharges = true, UseString = "Potion", UseInt4 = 3, ItemReturned = "vialEmpty", Potion = new() { new("Strength", 5) } });
            itemsToAdd.Add(new Item("Magic potion", "Temporarily boosts your Magic level by 5.", "potionMagic", Color.CadetBlue, 80) { UsesCharges = true, UseString = "Potion", UseInt4 = 3, ItemReturned = "vialEmpty", Potion = new() { new("Magic", 5) } });
            itemsToAdd.Add(new Item("Defense potion", "Temporarily boosts your Defense level by 5.", "potionDefense", Color.Lime, 50) { UsesCharges = true, UseString = "Potion", UseInt4 = 3, ItemReturned = "vialEmpty", Potion = new() { new("Defense", 5) } });
            itemsToAdd.Add(new Item("Combat potion", "Temporarily boosts your Attack and Strength levels by 5 each.", "potionCombat", Color.SpringGreen, 70) { UsesCharges = true, UseString = "Potion", UseInt4 = 3, ItemReturned = "vialEmpty", Potion = new() { new("Attack", 5), new("Strength", 5) } });
            itemsToAdd.Add(new Item("Cooking potion", "Temporarily boosts your Cooking level by 5.", "potionCooking", Color.Orange, 50) { UsesCharges = true, UseString = "Potion", UseInt4 = 3, ItemReturned = "vialEmpty", Potion = new() { new("Cooking", 5) } });
            itemsToAdd.Add(new Item("Ranging potion", "Temporarily boosts your Ranged level by 5.", "potionRanging", Color.Cyan, 90) { UsesCharges = true, UseString = "Potion", UseInt4 = 3, ItemReturned = "vialEmpty", Potion = new() { new("Ranged", 5) } });
            itemsToAdd.Add(new Item("Energy potion", "Energizes you to receive up to 5% additional experience from all actions.", "potionEnergy", Color.DeepPink.GetDark(), 50) { UsesCharges = true, UseString = "Potion", UseInt4 = 3, ItemReturned = "vialEmpty", Potion = new() { new("Experience", 5) } });
            itemsToAdd.Add(new Item("Restore potion", "Restores reduced stats by up to 5 levels per sip.", "potionRestore", Color.Salmon, 30) { UsesCharges = true, UseString = "Potion", UseInt4 = 3, ItemReturned = "vialEmpty", Potion = new() { new("Restore", 5) } });
            itemsToAdd.Add(new Item("Antipoison", "Cures poison and provides immunity to poison for two minutes.", "potionAntipoison", Color.Lime, 90) { UsesCharges = true, UseString = "Potion", UseInt4 = 3, ItemReturned = "vialEmpty", Potion = new() { new("Antipoison", 2) } });
            itemsToAdd.Add(new Item("Super strength potion", "Temporarily boosts your Strength level by 10.", "potionStrengthSuper", Color.White, 110) { UsesCharges = true, UseString = "Potion", UseInt4 = 3, ItemReturned = "vialEmpty", Potion = new() { new("Strength", 10) } });
             

            // Japanese herb set
            itemsToAdd.Add(new Item("Midori seed", "A midori seed - plant in an herb patch (1).", "seedMidori", Color.ForestGreen, 10, true) {
                UseString = "PlantSeed", UseString2 = "Herb", UseString3 = "grimyMidori", UseInt = 1 /* Level */,  UseInt2 = 20 /* Exp On Harvest */, UseInt3 = 4800 /* Growth time in seconds */ 
            });
            itemsToAdd.Add(new Item("Kiiro seed", "A kiiro seed - plant in an herb patch (10).", "seedKiiro", Color.ForestGreen, 20, true) {
                UseString = "PlantSeed", UseString2 = "Herb", UseString3 = "grimyKiiro", UseInt = 10 /* Level */,  UseInt2 = 30 /* Exp On Harvest */, UseInt3 = 4800 /* Growth time in seconds */ 
            });
            itemsToAdd.Add(new Item("Murasaki seed", "A murasaki seed - plant in an herb patch (20).", "seedMurasaki", Color.ForestGreen, 30, true) {
                UseString = "PlantSeed", UseString2 = "Herb", UseString3 = "grimyMurasaki", UseInt = 20 /* Level */,  UseInt2 = 40 /* Exp On Harvest */, UseInt3 = 4800 /* Growth time in seconds */ 
            });
            itemsToAdd.Add(new Item("Mazent seed", "A mazent seed - plant in an herb patch (30).", "seedMazent", Color.ForestGreen, 40, true) {
                UseString = "PlantSeed", UseString2 = "Herb", UseString3 = "grimyMazent", UseInt = 30 /* Level */,  UseInt2 = 50 /* Exp On Harvest */, UseInt3 = 4800 /* Growth time in seconds */ 
            });
            itemsToAdd.Add(new Item("Kuriiro seed", "A kuriiro seed - plant in an herb patch (40).", "seedKuriiro", Color.ForestGreen, 50, true) {
                UseString = "PlantSeed", UseString2 = "Herb", UseString3 = "grimyKuriiro", UseInt = 40 /* Level */,  UseInt2 = 60 /* Exp On Harvest */, UseInt3 = 4800 /* Growth time in seconds */ 
            });
            itemsToAdd.Add(new Item("Kusa seed", "A kusa seed - plant in an herb patch (50).", "seedKusa", Color.ForestGreen, 60, true) {
                UseString = "PlantSeed", UseString2 = "Herb", UseString3 = "grimyKusa", UseInt = 50 /* Level */,  UseInt2 = 70 /* Exp On Harvest */, UseInt3 = 4800 /* Growth time in seconds */ 
            });
            itemsToAdd.Add(new Item("Nokoribi seed", "A nokoribi seed - plant in an herb patch (60).", "seedNokoribi", Color.ForestGreen, 70, true) {
                UseString = "PlantSeed", UseString2 = "Herb", UseString3 = "grimyNokoribi", UseInt = 60 /* Level */,  UseInt2 = 80 /* Exp On Harvest */, UseInt3 = 4800 /* Growth time in seconds */ 
            });
            itemsToAdd.Add(new Item("Ao seed", "An ao seed - plant in an herb patch (70).", "seedAo", Color.ForestGreen, 80, true) {
                UseString = "PlantSeed", UseString2 = "Herb", UseString3 = "grimyAo", UseInt = 70 /* Level */,  UseInt2 = 90 /* Exp On Harvest */, UseInt3 = 4800 /* Growth time in seconds */ 
            });
            itemsToAdd.Add(new Item("Umi seed", "An umi seed - plant in an herb patch (80).", "seedUmi", Color.ForestGreen, 90, true) {
                UseString = "PlantSeed", UseString2 = "Herb", UseString3 = "grimyUmi", UseInt = 80 /* Level */,  UseInt2 = 100 /* Exp On Harvest */, UseInt3 = 4800 /* Growth time in seconds */ 
            });
            itemsToAdd.Add(new Item("Aka seed", "An aka seed - plant in an herb patch (90).", "seedAka", Color.ForestGreen, 100, true) {
                UseString = "PlantSeed", UseString2 = "Herb", UseString3 = "grimyAka", UseInt = 90 /* Level */,  UseInt2 = 110 /* Exp On Harvest */, UseInt3 = 4800 /* Growth time in seconds */ 
            });

            itemsToAdd.Add(new Item("Grimy midori", "A green herb, used in Alchemy (1).", "grimyMidori", Color.ForestGreen, 40) { UseString = "CleanHerb", ItemReturned = "cleanMidori", UseInt = 1, UseInt2 = 3 });
            itemsToAdd.Add(new Item("Grimy kiiro", "A yellow herb, used in Alchemy (10).", "grimyKiiro", Color.Yellow, 90) { UseString = "CleanHerb", ItemReturned = "cleanKiiro", UseInt = 10, UseInt2 = 4 });
            itemsToAdd.Add(new Item("Grimy murasaki", "A purple herb, used in Alchemy (20).", "grimyMurasaki", Color.MediumPurple, 190) { UseString = "CleanHerb", ItemReturned = "cleanMurasaki", UseInt = 20, UseInt2 = 5 });
            itemsToAdd.Add(new Item("Grimy mazent", "A pink herb, used in Alchemy (30).", "grimyMazent", Color.LightPink, 290) { UseString = "CleanHerb", ItemReturned = "cleanMazent", UseInt = 30, UseInt2 = 6 });
            itemsToAdd.Add(new Item("Grimy kuriiro", "A maroon herb, used in Alchemy (40).", "grimyKuriiro", Color.Maroon, 390) { UseString = "CleanHerb", ItemReturned = "cleanKuriiro", UseInt = 40, UseInt2 = 7 });
            itemsToAdd.Add(new Item("Grimy kusa", "A light green herb, used in Alchemy (50).", "grimyKusa", Color.Lime, 490) { UseString = "CleanHerb", ItemReturned = "cleanKusa", UseInt = 50, UseInt2 = 8 });
            itemsToAdd.Add(new Item("Grimy nokoribi", "An orange herb, used in Alchemy (60).", "grimyNokoribi", Color.Orange, 590) { UseString = "CleanHerb", ItemReturned = "cleanNokoribi", UseInt = 60, UseInt2 = 9 });
            itemsToAdd.Add(new Item("Grimy ao", "A blue herb, used in Alchemy (70).", "grimyAo", Color.DodgerBlue, 690) { UseString = "CleanHerb", ItemReturned = "cleanAo", UseInt = 70, UseInt2 = 10 });
            itemsToAdd.Add(new Item("Grimy umi", "A bluish-green herb, used in Alchemy (80).", "grimyUmi", Color.AnsiCyan, 790) { UseString = "CleanHerb", ItemReturned = "cleanUmi", UseInt = 80, UseInt2 = 11 });
            itemsToAdd.Add(new Item("Grimy aka", "A red herb, used in Alchemy (90).", "grimyAka", Color.Crimson, 890) { UseString = "CleanHerb", ItemReturned = "cleanAka", UseInt = 90, UseInt2 = 12 });

            itemsToAdd.Add(new Item("Clean midori", "A green herb, used in Alchemy (1).", "cleanMidori", Color.ForestGreen, 50) { Alchemy = new(4, -3, 4, 0, 1) });
            itemsToAdd.Add(new Item("Clean kiiro", "A yellow herb, used in Alchemy (10).", "cleanKiiro", Color.Yellow, 100) { Alchemy = new(-2, 2, -1, -5, 10) });
            itemsToAdd.Add(new Item("Clean murasaki", "A purple herb, used in Alchemy (20).", "cleanMurasaki", Color.MediumPurple, 200) { Alchemy = new(-3, 0, 4, -2, 20) });
            itemsToAdd.Add(new Item("Clean mazent", "A pink herb, used in Alchemy (30).", "cleanMazent", Color.LightPink, 300) { Alchemy = new(4, 2, 1, 1, 30) });
            itemsToAdd.Add(new Item("Clean kuriiro", "A maroon herb, used in Alchemy (40).", "cleanKuriiro", Color.Maroon, 400) { Alchemy = new(2, 3, 0, 2, 40) });
            itemsToAdd.Add(new Item("Clean kusa", "A light green herb, used in Alchemy (50).", "cleanKusa", Color.Lime, 500) { Alchemy = new(1, -3, -1, 1, 50) });
            itemsToAdd.Add(new Item("Clean nokoribi", "An orange herb, used in Alchemy (60).", "cleanNokoribi", Color.Orange, 600) { Alchemy = new(1, -1, 1, -2, 60) });
            itemsToAdd.Add(new Item("Clean ao", "A blue herb, used in Alchemy (70).", "cleanAo", Color.DodgerBlue, 700) { Alchemy = new(1, -1, -1, -1, 70) });
            itemsToAdd.Add(new Item("Clean umi", "A bluish-green herb, used in Alchemy (80).", "cleanUmi", Color.AnsiCyan, 800) { Alchemy = new(3, 0, 0, 0, 80) });
            itemsToAdd.Add(new Item("Clean aka", "A red herb, used in Alchemy (90).", "cleanAka", Color.Crimson, 900) { Alchemy = new(0, 1, 0, 1, 90) });
             
            
            // Hindi herb set
            itemsToAdd.Add(new Item("Neela seed", "A neela seed - plant in an herb patch (1).", "seedNeela", Color.ForestGreen, 10, true) {
                UseString = "PlantSeed", UseString2 = "Herb", UseString3 = "grimyNeela", UseInt = 1 /* Level */,  UseInt2 = 20 /* Exp On Harvest */, UseInt3 = 4800 /* Growth time in seconds */ 
            });
            itemsToAdd.Add(new Item("Nimbu seed", "A nimbu seed - plant in an herb patch (10).", "seedNimbu", Color.ForestGreen, 20, true) {
                UseString = "PlantSeed", UseString2 = "Herb", UseString3 = "grimyNimbu", UseInt = 10 /* Level */,  UseInt2 = 30 /* Exp On Harvest */, UseInt3 = 4800 /* Growth time in seconds */ 
            });
            itemsToAdd.Add(new Item("Baingani seed", "A baingani seed - plant in an herb patch (20).", "seedBaingani", Color.ForestGreen, 30, true) {
                UseString = "PlantSeed", UseString2 = "Herb", UseString3 = "grimyBaingani", UseInt = 20 /* Level */,  UseInt2 = 40 /* Exp On Harvest */, UseInt3 = 4800 /* Growth time in seconds */ 
            });
            itemsToAdd.Add(new Item("Lal seed", "A lal seed - plant in an herb patch (30).", "seedLal", Color.ForestGreen, 40, true) {
                UseString = "PlantSeed", UseString2 = "Herb", UseString3 = "grimyLal", UseInt = 30 /* Level */,  UseInt2 = 50 /* Exp On Harvest */, UseInt3 = 4800 /* Growth time in seconds */ 
            });
            itemsToAdd.Add(new Item("Hara seed", "A hara seed - plant in an herb patch (40).", "seedHara", Color.ForestGreen, 50, true) {
                UseString = "PlantSeed", UseString2 = "Herb", UseString3 = "grimyHara", UseInt = 40 /* Level */,  UseInt2 = 60 /* Exp On Harvest */, UseInt3 = 4800 /* Growth time in seconds */ 
            });
            itemsToAdd.Add(new Item("Gulabi seed", "A gulabi seed - plant in an herb patch (50).", "seedGulabi", Color.ForestGreen, 60, true) {
                UseString = "PlantSeed", UseString2 = "Herb", UseString3 = "grimyGulabi", UseInt = 50 /* Level */,  UseInt2 = 70 /* Exp On Harvest */, UseInt3 = 4800 /* Growth time in seconds */ 
            });
            itemsToAdd.Add(new Item("Siyan seed", "A siyan seed - plant in an herb patch (60).", "seedSiyan", Color.ForestGreen, 70, true) {
                UseString = "PlantSeed", UseString2 = "Herb", UseString3 = "grimySiyan", UseInt = 60 /* Level */,  UseInt2 = 80 /* Exp On Harvest */, UseInt3 = 4800 /* Growth time in seconds */ 
            });
            itemsToAdd.Add(new Item("Sharab seed", "A sharab seed - plant in an herb patch (70).", "seedSharab", Color.ForestGreen, 80, true) {
                UseString = "PlantSeed", UseString2 = "Herb", UseString3 = "grimySharab", UseInt = 70 /* Level */,  UseInt2 = 90 /* Exp On Harvest */, UseInt3 = 4800 /* Growth time in seconds */ 
            });
            itemsToAdd.Add(new Item("Peela seed", "A peela seed - plant in an herb patch (80).", "seedPeela", Color.ForestGreen, 90, true) {
                UseString = "PlantSeed", UseString2 = "Herb", UseString3 = "grimyPeela", UseInt = 80 /* Level */,  UseInt2 = 100 /* Exp On Harvest */, UseInt3 = 4800 /* Growth time in seconds */ 
            });
            itemsToAdd.Add(new Item("Narangi seed", "A narangi seed - plant in an herb patch (90).", "seedNarangi", Color.ForestGreen, 100, true) {
                UseString = "PlantSeed", UseString2 = "Herb", UseString3 = "grimyNarangi", UseInt = 90 /* Level */,  UseInt2 = 110 /* Exp On Harvest */, UseInt3 = 4800 /* Growth time in seconds */ 
            });

            itemsToAdd.Add(new Item("Grimy neela", "A blue herb, used in Alchemy (1).", "grimyNeela", Color.DodgerBlue, 40) { UseString = "CleanHerb", ItemReturned = "cleanNeela", UseInt = 1, UseInt2 = 3 });
            itemsToAdd.Add(new Item("Grimy nimbu", "A light green herb, used in Alchemy (10).", "grimyNimbu", Color.Lime, 90) { UseString = "CleanHerb", ItemReturned = "cleanNimbu", UseInt = 10, UseInt2 = 4 });
            itemsToAdd.Add(new Item("Grimy baingani", "A purple herb, used in Alchemy (20).", "grimyBaingani", Color.MediumPurple, 190) { UseString = "CleanHerb", ItemReturned = "cleanBaingani", UseInt = 20, UseInt2 = 5 });
            itemsToAdd.Add(new Item("Grimy lal", "A red herb, used in Alchemy (30).", "grimyLal", Color.Crimson, 290) { UseString = "CleanHerb", ItemReturned = "cleanLal", UseInt = 30, UseInt2 = 6 });
            itemsToAdd.Add(new Item("Grimy hara", "A green herb, used in Alchemy (40).", "grimyHara", Color.ForestGreen, 390) { UseString = "CleanHerb", ItemReturned = "cleanHara", UseInt = 40, UseInt2 = 7 });
            itemsToAdd.Add(new Item("Grimy gulabi", "A pink herb, used in Alchemy (50).", "grimyGulabi", Color.LightPink, 490) { UseString = "CleanHerb", ItemReturned = "cleanGulabi", UseInt = 50, UseInt2 = 8 });
            itemsToAdd.Add(new Item("Grimy siyan", "A bluish-green herb, used in Alchemy (60).", "grimySiyan", Color.AnsiCyan, 590) { UseString = "CleanHerb", ItemReturned = "cleanSiyan", UseInt = 60, UseInt2 = 9 });
            itemsToAdd.Add(new Item("Grimy sharab", "A maroon herb, used in Alchemy (70).", "grimySharab", Color.Maroon, 690) { UseString = "CleanHerb", ItemReturned = "cleanSharab", UseInt = 70, UseInt2 = 10 });
            itemsToAdd.Add(new Item("Grimy peela", "A yellow herb, used in Alchemy (80).", "grimyPeela", Color.Yellow, 790) { UseString = "CleanHerb", ItemReturned = "cleanPeela", UseInt = 80, UseInt2 = 11 });
            itemsToAdd.Add(new Item("Grimy narangi", "An orange herb, used in Alchemy (90).", "grimyNarangi", Color.Orange, 890) { UseString = "CleanHerb", ItemReturned = "cleanNarangi", UseInt = 90, UseInt2 = 12 });

            itemsToAdd.Add(new Item("Clean neela", "A blue herb, used in Alchemy (1).", "cleanNeela", Color.DodgerBlue, 50) { Alchemy = new(4, -1, 3, -3, 1) });
            itemsToAdd.Add(new Item("Clean nimbu", "A light green herb, used in Alchemy (10).", "cleanNimbu", Color.Lime, 100) { Alchemy = new(3, -4, 3, 0, 10) });
            itemsToAdd.Add(new Item("Clean baingani", "A purple herb, used in Alchemy (20).", "cleanBaingani", Color.MediumPurple, 200) { Alchemy = new(-1, 4, -2, 2, 20) });
            itemsToAdd.Add(new Item("Clean lal", "A red herb, used in Alchemy (30).", "cleanLal", Color.Crimson, 300) { Alchemy = new(0, -6, -1, 1, 30) });
            itemsToAdd.Add(new Item("Clean hara", "A green herb, used in Alchemy (40).", "cleanHara", Color.ForestGreen, 400) { Alchemy = new(-3, 0, 0, 4, 40) });
            itemsToAdd.Add(new Item("Clean gulabi", "A pink herb, used in Alchemy (50).", "cleanGulabi", Color.LightPink, 500) { Alchemy = new(-1, -2, 1, 2, 50) });
            itemsToAdd.Add(new Item("Clean siyan", "A bluish-green herb, used in Alchemy (60).", "cleanSiyan", Color.AnsiCyan, 600) { Alchemy = new(-2, 0, 0, -3, 60) });
            itemsToAdd.Add(new Item("Clean sharab", "A maroon herb, used in Alchemy (70).", "cleanSharab", Color.Maroon, 700) { Alchemy = new(2, 0, -1, 1, 70) });
            itemsToAdd.Add(new Item("Clean peela", "A yellow herb, used in Alchemy (80).", "cleanPeela", Color.Yellow, 800) { Alchemy = new(1, 0, 1, 1, 80) });
            itemsToAdd.Add(new Item("Clean narangi", "An orange herb, used in Alchemy (90).", "cleanNarangi", Color.Orange, 900) { Alchemy = new(0, 0, -2, 0, 90) });
            

            for (int i = 0; i < itemsToAdd.Count; i++) {
                ItemLibrary.Add(itemsToAdd[i].ID, itemsToAdd[i]);
            }
        }
    }
}
