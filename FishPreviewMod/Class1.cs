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

                        // Tamanho padrão do quadro
                        int boxSize = 90;

                        // Ancoragem Imune ao Zoom do Mobile: Topo Central da Tela!
                        // Assim, ele nunca se mistura com a barra de pesca nem é afetado pelo zoom.
                        int boxX = (Game1.uiViewport.Width - boxSize) / 2;
                        int boxY = 20; // 20 pixels de distância do teto da tela

                        // Desenha o quadrado
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

                        // Desenha o peixe centralizado dentro da caixa
                        float fishScale = 1.25f;
                        float drawnSize = 64f * fishScale;
                        
                        Vector2 iconPos = new Vector2(
                            boxX + (boxSize - drawnSize) / 2f,
                            boxY + (boxSize - drawnSize) / 2f
                        );

                        fishItem.drawInMenu(e.SpriteBatch, iconPos, fishScale);
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