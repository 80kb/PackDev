using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PackDevNET
{
    internal class SlotDatabase
    {
        // Track Slots: Luigi Circuit - N64 Bowser's Castle
        public static List<Slot> TrackSlots = new List<Slot>()
        {
            new Slot(0x08, 0x75, "Luigi Circuit", "beginner_course"),
            new Slot(0x01, 0x77, "Moo Moo Meadows", "farm_course"),
            new Slot(0x02, 0x79, "Mushroom Gorge", "kinoko_course"),
            new Slot(0x04, 0x7B, "Toad's Factory", "factory_course"),
            new Slot(0x00, 0x7D, "Mario Circuit", "castle_course"),
            new Slot(0x05, 0x7F, "Coconut Mall", "shopping_course"),
            new Slot(0x06, 0x81, "DK Summit", "boardcross_course"),
            new Slot(0x07, 0x83, "Wario's Gold Mine", "truck_course"),
            new Slot(0x09, 0x87, "Daisy Circuit", "senior_course"),
            new Slot(0x0F, 0x85, "Koopa Cape", "water_course"),
            new Slot(0x0B, 0x8F, "Maple Treeway", "treehouse_course"),
            new Slot(0x03, 0x8B, "Grumble Volcano", "volcano_course"),
            new Slot(0x0E, 0x89, "Dry Dry Ruins", "desert_course"),
            new Slot(0x0A, 0x8D, "Moonview Highway", "ridgehighway_course"),
            new Slot(0x0C, 0x91, "Bowser's Castle", "koopa_course"),
            new Slot(0x0D, 0x93, "Rainbow Road", "rainbow_course"),
            new Slot(0x10, 0xA5, "GCN Peach Beach", "old_peach_gc"),
            new Slot(0x14, 0xAD, "DS Yoshi Falls", "old_falls_ds"),
            new Slot(0x19, 0x97, "SNES Ghost Valley 2", "old_obake_sfc"),
            new Slot(0x1A, 0x9F, "N64 Mario Raceway", "old_mario_64"),
            new Slot(0x1B, 0x9D, "N64 Sherbet Land", "old_sherbet_64"),
            new Slot(0x1F, 0x95, "GBA Shy Guy Beach", "old_heyho_gba"),
            new Slot(0x17, 0xAF, "DS Delfino Square", "old_town_ds"),
            new Slot(0x12, 0xA9, "GCN Waluigi Stadium", "old_waluigi_gc"),
            new Slot(0x15, 0xB1, "DS Desert Hills", "old_desert_ds"),
            new Slot(0x1E, 0x9B, "GBA Bowser Castle 3", "old_koopa_gba"),
            new Slot(0x1D, 0xA1, "N64 DK's Jungle Parkway", "old_donkey_64"),
            new Slot(0x11, 0xA7, "GCN Mario Circuit", "old_mario_gc"),
            new Slot(0x18, 0x99, "SNES Mario Circuit 3", "old_mario_sfc"),
            new Slot(0x16, 0xB3, "DS Peach Gardens", "old_garden_ds"),
            new Slot(0x13, 0xAB, "GCN DK Mountain", "old_donkey_gc"),
            new Slot(0x1C, 0xA3, "N64 Bowser's Castle", "old_koopa_64")
        };

        // Arena Slots: Block Plaza - DS Twilight House
        public static List<Slot> ArenaSlots = new List<Slot>()
        {
            new Slot(0x21, 0xB7, "Block Plaza", "block_battle"),
            new Slot(0x20, 0xB5, "Delfino Pier", "venice_battle"),
            new Slot(0x23, 0xB9, "Funky Stadium", "skate_battle"),
            new Slot(0x22, 0xBB, "Chain Chomp Wheel", "casino_battle"),
            new Slot(0x24, 0xBD, "Thwomp Desert", "sand_battle"),
            new Slot(0x27, 0xC3, "SNES Battle Course 4", "old_battle4_sfc"),
            new Slot(0x28, 0xC5, "GBA Battle Course 3", "old_battle3_gba"),
            new Slot(0x29, 0xC7, "N64 Skyscraper", "old_matenro_64"),
            new Slot(0x25, 0xBF, "GCN Cookie Land", "old_cookieland_gc"),
            new Slot(0x29, 0xC1, "DS Twilight House", "old_house_ds")
        };

        // Special Case: Galaxy Colosseum
        public static Slot GalaxyColosseum = new Slot(0x36, 0xC9, "Galaxy Colosseum", "ring_mission");
    }
}
