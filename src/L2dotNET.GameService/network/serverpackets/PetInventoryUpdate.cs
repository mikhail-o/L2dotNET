﻿using System.Collections.Generic;
using L2dotNET.GameService.Model.Items;
using L2dotNET.Network;

namespace L2dotNET.GameService.Network.Serverpackets
{
    class PetInventoryUpdate : GameserverPacket
    {
        protected List<object[]> Update = new List<object[]>();

        public void AddNewItem(L2Item item)
        {
            Update.Add(new object[] { item, (short)1 });
        }

        public void AddModItem(L2Item item)
        {
            Update.Add(new object[] { item, (short)2 });
        }

        public void AddDelItem(L2Item item)
        {
            Update.Add(new object[] { item, (short)3 });
        }

        public override void Write()
        {
            WriteByte(0xb4);
            WriteShort(Update.Count);

            foreach (object[] obj in Update)
            {
                WriteShort((short)obj[1]);

                L2Item item = (L2Item)obj[0];

                WriteInt(item.ObjId);
                WriteInt(item.Template.ItemId);
                WriteInt(0); //loc
                WriteLong(item.Count);

                WriteShort(item.Template.Type2);
                WriteShort(0);
                WriteShort(item.IsEquipped);

                WriteInt(item.Template.BodyPart);
                WriteShort(item.Enchant);
                WriteShort(0);

                WriteInt(item.AugmentationId);
                WriteInt(item.Durability);
                WriteInt(item.LifeTimeEnd());

                WriteShort(item.AttrAttackType);
                WriteShort(item.AttrAttackValue);

                WriteShort(item.Enchant1);
                WriteShort(item.Enchant2);
                WriteShort(item.Enchant3);
            }
        }
    }
}