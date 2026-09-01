# Fish Preview para Stardew Valley (Android)

Um mod leve para o SMAPI no Stardew Valley que exibe uma caixinha de interface quadrada com a pré-visualização em tempo real (sprite) centralizada do peixe que você fisgou durante o minigame de pesca.

![Versão do Jogo](https://img.shields.io/badge/Stardew%20Valley-v1.6-brightgreen) ![SMAPI](https://img.shields.io/badge/SMAPI-v4.3.2.5-blue) ![Plataforma](https://img.shields.io/badge/Plataforma-Android-orange)

## Como Funciona

O mod intercepta o minigame de pesca (`BobberBar`) em tempo real. Ele utiliza reflexão interna do jogo para capturar a identificação exata do peixe que fisgou o anzol, instancia o item correspondente e desenha uma caixinha de menu com o sprite do peixe grandão e perfeitamente centralizado ao lado esquerdo da barra de pesca.

## Testes e Compatibilidade

- **Android**: Desenvolvido, compilado em .NET 9 e **testado e validado diretamente no Android**, rodando com o SMAPI e o launcher da equipe do NRTnarathip e Eky-Team.
- **PC (Windows / Mac / Linux)**: O mod foi estruturado com as APIs padrão do SMAPI, mas **não foi testado no PC**. Portanto, embora possa funcionar, não há garantia de que rode no computador sem ajustes adicionais. O foco total deste projeto é a experiência no Android.

## Instalação

1. Baixe o arquivo `.zip` mais recente na aba de [Releases](../../releases) ou compile a partir do código-fonte.
2. Extraia a pasta do mod diretamente para o diretório de **Mods** do SMAPI no seu dispositivo Android.
3. Abra o jogo utilizando o launcher do SMAPI para Android.

## Compilando a partir do Código-Fonte

Caso queira compilar o mod por conta própria:

1. Clone o repositório:
   ```bash
   git clone [https://github.com/SEU_USUARIO/Fish-previum-.git](https://github.com/SEU_USUARIO/Fish-previum-.git)
