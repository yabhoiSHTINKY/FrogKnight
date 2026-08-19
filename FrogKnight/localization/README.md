# Translation

To add a translation fork the repository and add your translation in the appropriate file in this directory. Once you have translated the files, make a pull request requesting to merge your changes into the main branch. Generally speaking it will require another person who speaks the language to review it before it will be accepted. Neither of the devs are multi-lingual, so it will (unfortunately) need to be a community effort on that front. Further down this file I have created a cheat-sheet for the formatting that StS2 uses. For the most part, anything within `[]` or `{}` should not be translated with some exceptions.

## Formatting Guidelines
1. Try to mimic the layout of the English cards. If this is not possible due to language differences, use your best judgment.
2. Don't overcrowd cards. When possible use newlines to break up effects.
3. Use consistent verbage. If you use `Apply` for giving a debuff to enemies, use a different word for when the player gains a buff.
4. Any Buff, Debuff, Power, or Card Name should be gold.
5. `Hand`, `Draw Pile`, `Discard Pile`, and `Exhaust Pile` should be gold.
6. In `power.json` buff/debuff quantities should be blue.

## "Exception" Examples
### Example 1 (`powers.json` -> `FROGKNIGHT-GRAPPLE_FROG_POWER.smartDescription`):
```json
"At the end of {OnPlayer:your turn take, take|its turn, takes}...",
```
Of note is the selector for what turn it is. Specifically the `OnPlayer` key word. This should not be translated. The text following this depends on what the "function" does.
i.e. if the description is on a player use the text `your turn, take` otherwise it will use `its turn, takes`

### Example 2 (`cards.json` -> `"FROGKNIGHT-PARRY.description"`):
```json
  "Gain {Block:diff()} [gold]Block[/gold].\nDraw {Cards:diff()} card{Cards:plural:|s}.",
```
Here `card` is followed by `{Cards:plural:|s}`. This checks the number of cards being drawn and will add an s if it is more than one. This is done because the card goes from drawing 1 card to 2 cards after it is upgraded. If the value will never change, then hardcoding the description is preferable.


## Function/Formatting Reference
### Text Formatting
`\n`
- inserts a new line.

`[gold]`...`[/gold]`
- makes text gold

`[blue]`...`[/blue]`
- makes text blue

`[green]`...`[/green]`
- makes text green

`[i]`...`[/i]`
- makes text italic

`[font_size=<insert_number_here>]`...`[/font_size]`
- changes font size
  - Usage: `[font_size=3]`bepis`[/font_size]`)
  
### Dependent Formatting
`{...}`
- Will display the associated `CannonicalVar`'s or  value.
  -  (e.g. `{Damage}`,`{StrengthPower}`, `{WeakPower}`)

`{Amount}`
- **Only for Powers**. Will display the number of stacks of a given power on a character.
  - This should only be used in the `SmartDescription`.
    
`:diff()`
- When used after a number inserting value, it will allow it to change.
  - Usage: `{Damage:diff()}`
    
`:energyIcons()`
-  will display an number of energy icons equal to the value of the preceding value.

`{OnPlayer:}`
- will display different text if the buff/debuff is applied to a player or enemy.
  - Usage: `{OnPlayer:<true_text>|<false_text>}`
  
`{:plural:}`
- will display different text if evaluated number is more than 1.
  - Usage: `{<Value_to_be_checked>:plural:<not_plural_text>|<plural_text>}`



As of writing this document only these files contain text requiring translation:
- `ancients.json`
- `cards.json`
- `characters.json`
- `powers.json`
- `relics.json`
