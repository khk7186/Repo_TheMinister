public enum ESlot
{
    one = 1,
    two = 2,
    three =3,
    four= 4,
    five= 5,
    six = 6,
    seven = 7
}
public interface ICharacterSelect
{
    public void ChooseCharacter(Character character);
    public void SetupSlotIcon();

    public void CloseInventory();
    public void CloseInventory(CharacterUI current);
}

