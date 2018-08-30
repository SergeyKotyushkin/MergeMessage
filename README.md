# MergeMessage
A solution that creates message for merge.


# Installation
1. Download last release
2. Build solution
3. Copy the *settings.example.ini* file near with the built assemblies into the *settings.ini* file
4. Change the *settings.ini* file for the current needs (more information in the Settings section below)
5. Run application


# Settings
The *settings.ini* file can contain next settings:
1. Branches
    Specifies a list of available branches.
    Each branch must be defined with on line in the settings. 
    It must have next format: `Branch:BranchName,BranchFromat[,BranchAdditional]`
    
    Where: 
    - `Branch:` - special prefix for the Branch setting
    - `BranchName` - a name of the branch in the drop down list in the application
    - `BranchFromat` - a format for the branch output in the result merge messaage
    - `BranchAdditional` - a label for the branch additional (optional, only for branches with inserted text)
        
    Branch configuration examples: 
    - `Branch:Develop,Dev`
    - `Branch:Release,Release-{0},Release number`
    
    The settings can contain many Branch counfigurations.
2. SingleModeMessageFormat
    Defines a format for the result merge message in a *Single* mode.
    It must have next format: `SingleModeMessageFormat:MessageFormat`
    
    Where: 
    - `SingleModeMessageFormat:` - special prefix for the SingleModeMessageFormat setting
    - `MessageFormat` - a format for the result merge message in a *Single* mode
    
    SingleModeMessageFormat configuration example: 
    - `SingleModeMessageFormat:Merged {0} from {1} for {2}`
    
    Where: 
    - `{0}` - will be replaced by a changeset number
    - `{1}` - will be replaced by a branch `BranchFromat`
    - `{2}` - will be replaced by a changeset commit message
    
    The settings can contain many SingleModeMessageFormat counfigurations but only first wil be used.
3. MultiModeMessageFormat
    Defines a format for the result merge message in a *Multi* mode.
    It must have next format: `MultiModeMessageFormat:MessageFormat`
    Where: 
    - `MultiModeMessageFormat:` - special prefix for the MultiModeMessageFormat setting
    - `MessageFormat` - a format for the result merge message in a *Multi* mode
    
    MultiModeMessageFormat configuration example: 
    - `MultiModeMessageFormat:Merged {0} from {1} for {2}`
    
    Where: 
    - `{0}` - will be replaced by a changeset numbers joined with comma
    - `{1}` - will be replaced by a branch `BranchFromat`
    - `{2}` - will be replaced by a changeset task numbers joined with comma
    
    The settings can contain many MultiModeMessageFormat counfigurations but only first wil be used.
4. ChangesetNumberFormat
    Defines a format for the changeset number in the result merge message for the both modes.
    It must have next format: `ChangesetNumberFormat:ChangesetNumberFormat`
    
    Where: 
    - `ChangesetNumberFormat:` - special prefix for the ChangesetNumberFormat setting
    - `ChangesetNumberFormat` - a format for the changeset number in the result merge message for the both modes
    
    ChangesetNumberFormat configuration example: 
    - `ChangesetNumberFormat:#{0}`
    
    Where: 
    - `{0}` - will be replaced by a changeset number
    
    The settings can contain many ChangesetNumberFormat counfigurations but only first wil be used.
5. ChangesetTaskPrefix
    Defines a task prefix.
    It must have next format: `ChangesetTaskPrefix:ChangesetTaskPrefix`
    
    Where: 
    - `ChangesetTaskPrefix:` - special prefix for the ChangesetTaskPrefix setting
    - `ChangesetTaskPrefix` - a task prefix
    
    ChangesetTaskPrefix configuration example: 
    - `ChangesetTaskPrefix:Task`
    
    The settings can contain many ChangesetTaskPrefix counfigurations but only first wil be used.


# Modes
It is available two modes:
1. Single
    For each input messages pasted in the input text box will be generated separete merge message with a full changeset commit message.
2. Multi
    For all input messages pasted in the input text box will be generated only one merge message with changeset task numbers.


# Usage instructions
1. Open Visual Studio
2. Open the Source Control Explorer
3. Chose a necessary branch
4. Click Merge on the chosen branch
5. Chose a target branch
6. Copy full line of a changeset (or the few lines of the few changesets) for mergering on the step of selection changesets for mergering
7. Run the MergeMessage application
8. Paste copied changeset line into the Input Message text box
9. From the From Branch drop down chose a branch for which you want mergering
10. Chose a necessary Mode
11. Click Create
12. Get generated merge message in the Result text box
