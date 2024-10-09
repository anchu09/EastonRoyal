using System.Collections.Generic;
using UnityEngine;

// Central audio manager — one public Play method per clip, routed through a null-safe helper.
public class AudioManager : Singleton<AudioManager>
{
    public AudioSource ambientMusic1;
    public AudioSource ambientMusic2;

    public AudioSource lightMatchSound;
    public AudioSource lightCandleWithMatchSound;
    public AudioSource openWoodenPanelSound;
    public AudioSource rotatePrintPanelSound;
    public AudioSource secretBookcaseDoorSound;
    public AudioSource leverClickSound;
    public AudioSource movePuzzleBlocksSound;
    public AudioSource metalDropSound;
    public AudioSource openDungeonCellSound;
    public AudioSource openDoorLockSound;
    public AudioSource pullCeilingChainSound;
    public AudioSource stairsFromWallSound;
    public AudioSource fireplaceSound;

    // Library / office sound effects
    public AudioSource randomPianoNotesSound;
    public AudioSource pourLiquidSound;
    public AudioSource openDrawerSound;
    public AudioSource thumbtackSound;
    public AudioSource openChestSound;
    public AudioSource combinationInputSound;
    public AudioSource moveStatueSound;
    public AudioSource toggleMenusSound;
    public AudioSource spawnInventoryItemSound;
    public AudioSource buttonPressSound;
    public AudioSource levelTransitionSound;
    public AudioSource objectDropSound;
    public AudioSource pickUpPaperSound;
    public AudioSource paperUnlockedSound;
    public AudioSource bottleCorrectSound;
    public AudioSource bottleIncorrectSound;

    public AudioSource narrationWhereAmI;
    public AudioSource narrationChestOpened;
    public AudioSource narrationDrinks;
    public AudioSource narrationSamplesCommon;
    public AudioSource narrationOfficeDoor;
    public AudioSource narrationLookGood;

    public AudioSource victoryJingle;

    private readonly HashSet<AudioSource> _playedOnce = new();

    private static void PlaySound(AudioSource source)
    {
        if (source != null)
            source.Play();
    }

    private void PlayOnce(AudioSource source)
    {
        if (source != null && _playedOnce.Add(source))
            source.Play();
    }

    public void PlayAmbientMusic1() => PlaySound(ambientMusic1);
    public void PlayAmbientMusic2() => PlaySound(ambientMusic2);

    public void PlayLightMatch()              => PlaySound(lightMatchSound);
    public void PlayLightCandleWithMatch() => PlaySound(lightCandleWithMatchSound);
    public void PlayOpenWoodenPanel()           => PlaySound(openWoodenPanelSound);
    public void PlayRotatePrintPanel() => PlaySound(rotatePrintPanelSound);
    public void PlayOpenSecretBookcase() => PlaySound(secretBookcaseDoorSound);
    public void PlayLeverClick()            => PlaySound(leverClickSound);
    public void PlayMovePuzzleBlocks()      => PlaySound(movePuzzleBlocksSound);
    public void PlayMetalDrop()          => PlaySound(metalDropSound);
    public void PlayOpenDungeonCell()           => PlaySound(openDungeonCellSound);
    public void PlayOpenDoorLock()        => PlaySound(openDoorLockSound);
    public void PlayPullCeilingChain()        => PlaySound(pullCeilingChainSound);
    public void PlayStairsFromWall()     => PlaySound(stairsFromWallSound);
    public void PlayFireplace()                => PlaySound(fireplaceSound);

    // Library / office sound effects

    public void PlayRandomPianoNotes()          => PlaySound(randomPianoNotesSound);
    public void PlayPourLiquid()      => PlaySound(pourLiquidSound);
    public void PlayOpenDrawer()          => PlaySound(openDrawerSound);
    public void PlayThumbtack()          => PlaySound(thumbtackSound);
    public void PlayOpenChest()           => PlaySound(openChestSound);
    public void PlayCombinationInput()         => PlaySound(combinationInputSound);
    public void PlayMoveStatue()              => PlaySound(moveStatueSound);
    public void PlayToggleMenus()          => PlaySound(toggleMenusSound);
    public void PlaySpawnInventoryItem() => PlaySound(spawnInventoryItemSound);
    public void PlayButtonPress()          => PlaySound(buttonPressSound);
    public void PlayLevelTransition()             => PlaySound(levelTransitionSound);
    public void PlayObjectDrop()     => PlaySound(objectDropSound);
    public void PlayPickUpPaper()              => PlaySound(pickUpPaperSound);
    public void PlayPaperUnlocked()         => PlaySound(paperUnlockedSound);
    public void PlayBottleCorrect()              => PlaySound(bottleCorrectSound);
    public void PlayBottleIncorrect()               => PlaySound(bottleIncorrectSound);

    public void PlayNarrationWhereAmI()              => PlayOnce(narrationWhereAmI);
    public void ReproducirvozBaulAbierto()         => PlaySound(narrationChestOpened);
    public void ReproducirvozBebidas()             => PlayOnce(narrationDrinks);
    public void ReproducirvozPruebasAlgoEnComun()  => PlayOnce(narrationSamplesCommon);
    public void ReproducirvozPuertaDespacho()      => PlayOnce(narrationOfficeDoor);
    public void PlayNarrationLookGood()            => PlaySound(narrationLookGood);

    public void PlayVictory() => PlaySound(victoryJingle);
}
