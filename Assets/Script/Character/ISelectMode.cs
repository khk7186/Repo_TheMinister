
public interface ISelectMode 
{
    bool selectMode { get;}
    CharacterSlotForQuest CurrentSlot { get; set; }

    void SelectCharacter();
}
