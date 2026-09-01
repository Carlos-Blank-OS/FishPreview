using StardewModdingAPI;
using StardewModdingAPI.Events;
using StardewValley;
using StardewValley.Menus;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;

namespace FishPreviewMod
{
    public class Class1 : Mod
    {
        public override void Entry(IModHelper helper)
        {
            helper.Events.Display.RenderedHud += this.OnRenderedHud;
        }

        private void OnRenderedHud(object? sender, RenderedHudEventArgs e)
        {
            if (!Context.IsWorldReady)
                return;

            if (Game1.activeClickableMenu is BobberBar bobberBar)
            {
                try
                {
                    var fishIdField = Helper.Reflection.GetField<string>(bobberBar, "whichFish", false);
                    string fishId = fishIdField?.GetValue();

                    if (!string.IsNullOrEmpty(fishId) && ItemRegistry.Exists("(O)" + fishId))
                    {
                        Item fishItem = ItemRegistry.Create("(O)" + fishId);

                        // Quadrado bem grande e espaçoso (100x100)
                        int boxSize = 100;

                        var xField = Helper.Reflection.GetField<int>(bobberBar, "xPositionOnScreen", false);
                        var yField = Helper.Reflection.GetField<int>(bobberBar, "yPositionOnScreen", false);
                        
                        int barX = xField != null ? xField.GetValue() : Game1.uiViewport.Width / 2 - 100;
                        int barY = yField != null ? yField.GetValue() : Game1.uiViewport.Height / 2 - 150;

                        int boxX = barX - boxSize - 18;
                        int boxY = barY + 30;

                        // Desenha o quadrado grande estilo interface do jogo
                        IClickableMenu.drawTextureBox(
                            e.SpriteBatch,
                            Game1.menuTexture,
                            new Rectangle(0, 256, 60, 60),
                            boxX,
                            boxY,
                            boxSize,
                            boxSize,
                            Color.White,
                            1f,
                            true
                        );

                        // Centraliza matematicamente o sprite do peixe no meio exato do quadrado com escala maior
                        float scale = 1.25f;
                        float drawnSize = 64f * scale;
                        Vector2 iconPos = new Vector2(
                            boxX + (boxSize - drawnSize) / 2f,
                            boxY + (boxSize - drawnSize) / 2f
                        );

                        fishItem.drawInMenu(e.SpriteBatch, iconPos, scale);
                    }
                }
                catch (Exception ex)
                {
                    Monitor.Log($"Erro ao renderizar a pré-visualização do peixe: {ex.Message}", LogLevel.Trace);
                }
            }
        }
    }
}