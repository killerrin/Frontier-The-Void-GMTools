   M S B A M L   `   `   `  ���� T  PFrontier The Void GMTools, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullE'clr-namespace:Frontier_The_Void_GMToolsFrontier_The_Void_GMTools  *    $Frontier_The_Void_GMTools.CombatPage   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     @d2http://schemas.microsoft.com/expression/blend/2008     9local'clr-namespace:Frontier_The_Void_GMTools     X TXceed.Wpf.Toolkit, Version=2.5.0.0, Culture=neutral, PublicKeyToken=3e4669d2f30244f4:
wpftoolkit)http://schemas.xceed.com/wpf/xaml/toolkit    N� 
Background
  ����� N� Title$ Combat�� � DataContext ��    Locator �� Source# [   �� Path$ vm_CombatViewModel�.��� .+�]� .+���  �� Orientation$ Vertical=�$	��Top=�.+��� $ 
Horizontal=�$��0,5,0,0q�.+��� $ 
Horizontal=�.+��� $��
Group Name��$��0,0,0,0q��� -    ��Name$ textBox_CombatGroupName��$	��250��$��5,0,0,0q��� -   $��Add Battle Group��$��5,0,0,0q��� $ 
Horizontal=�$��	100,0,0,0q�.+��� -   $��Clear Simulation��$	��100���� -    ��Name$! simulatedCombatModeComboBox��$��5,0,0,0q�$	��240�� �� SelectedIndex$ 0��.@��� $�Randomized Targets���� -   $��Simulate Combat��$	��100��$��5,0,0,0q�$��Center=��� $��0,5,0,0q�$��Stretch=����� $ RoundsOfCombat����� .R��� 	 ��Name$	 roundContainer��$ Vertical=�$	��Top=�.+��� $ 
Horizontal=�.+��� -   $��X��$��0,0,0,0q��� $��10,0,0,0q��� $�Round: �� �� ��� *RoundNumber+d� 
 d�Name$
 hideShowToggleButton��$��	Hide/Show�� d� 	IsChecked$
 TrueY�$��0,10,0,0q�$��Stretch=���  ��Name$ combatForcesListBox��$	��300��$��0,5,0,0q�$	��Top=����� $ CombatForces�y���  �� ElementName$ hideShowToggleButton��$ 	IsChecked�   BooleanToVisibilityConverter �� 	Converter# [ ���� .R��� $ 
Horizontal=�$	��350������ .R��� $ Vertical=�.+��� $ 
Horizontal=�.+��� -   $��X��$��0,0,0,0q�{��� *Round.RoundLocked+  OppositeBooleanConverter# [ �� $��5,0,15,0q����� *Name+�� $��10,0,0,0q��� $�Total Units:�� �� ��� *
TotalUnits+ �� Mode$ OneWay=��� $��10,0,0,0q��� $	�HP:�� �� ��� *TotalHealth+$ OneWay=��� $��10,0,0,0q��� $	�AV:�� �� ��� *TotalAttack+$ OneWay=��� $��Invulnerable��$��10,2,0,0q� �� *IsInvulnerable+$ TwoWay=�{��� *Round.RoundLocked+# [ �� -   $��Add Unit��$��10,0,0,0q�$��55��{��� *Round.RoundLocked+# [ �� $ 
Horizontal=�$��0,5,0,0q�.+��� $��
Crew Score���� -	   $��5,0,0,0q�$��20������ *	CrewScore+$ TwoWay=�{��� *Round.RoundLocked+# [ $ OneWay=��� $ ��Attempt Electronic Warfare��$��10,0,0,0q� �� *AttemptElectronicWarfare+$ TwoWay=�{��� *Round.RoundLocked+# [ �� $��Skip Attack��$��10,0,0,0q� �� *
SkipAttack+$ TwoWay=�{��� *Round.RoundLocked+# [ �� $ 
Horizontal=�$��0,5,0,0q�.+��� $��Has Advanced Scanners��$��10,0,0,0q� �� *HasAdvancedScanners+$ TwoWay=�{��� *Round.RoundLocked+# [ �� $ Vertical=�$��0,5,0,0q�.+��� $ 
Horizontal=�.+��� $��	Attacking���� $ attackingSelector��$	��200��$��20,0,0,0q����� *Round.CombatForces+$ OneWay=�{��� *Round.RoundLocked+# [  �� SelectedItem �� *UI_ATTACKING+$ TwoWay=����� .R��� ���� *Name+��  ��Name$ addAttackingButton��-
   $	��Add��$��5,0,0,0q��� $ removeAttackingButton��-   $��Remove��$��5,0,0,0q��� ���� *	Attacking+���� .R�� .+��� ���� *Name+�� $��0,5,0,0q����� $ Units�$ OneWay=����� .R��� $ Vertical=�.+��� $ 
Horizontal=�.+��� -   $��X��{��� *CombatForce.Round.RoundLocked+# [ �� $��5,0,0,0q��� ��� $
 Name��� $��10,0,0,0q��� $
�Type�� �� ��� $ 
TypeOfUnit�  EnumSpaceConverter# [ �� $��10,0,0,0q��� $�Health���� -   $��2,0,0,0q�$��35������ *Health+$ TwoWay=�{��� *CombatForce.Round.RoundLocked+# [ $ OneWay=��� $��10,0,0,0q��� $�Attack���� -   $��2,0,0,0q�$��35������ *AttackPower+$ TwoWay=�{��� *CombatForce.Round.RoundLocked+# [ $ OneWay=��� $��Command & Control��$��10,0,0,0q� �� *IsCommandAndControl+$ TwoWay=�{��� *CombatForce.Round.RoundLocked+# [ $ OneWay=��� $ 
Horizontal=�.+��� $��Skip Attack��$��20,0,0,0q� �� *
SkipAttack+$ TwoWay=�{��� *CombatForce.Round.RoundLocked+# [ $ OneWay=��� $��Invulnerable��$��10,0,0,0q� �� *Invulnerable+$ TwoWay=�{��� *CombatForce.Round.RoundLocked+# [ $ OneWay=��� $��Detected��$��10,0,0,0q� �� *
Detected+$ TwoWay=�{��� *CombatForce.Round.RoundLocked+# [ $ OneWay=��� -   $��
Remove All��{��� *Round.RoundLocked+# [ $ OneWay=��� $ 
Horizontal=�.+��� $��Result����  �� TextWrapping$
 Wrap=� �� 
IsReadOnly . $��20,0,0,0q�$	��600��$��40������ *	Summary+$ OneWay=�#  Xceed.Wpf.Toolkit.ChildWindow  -     Name$ addUnitChildWindow��$��Center=�$��Center=�.���� $ Vertical=�.+��� $ 
Horizontal=�.+��� $��Preset���� -   $( "presetComboBox_addUnit_childWindow��$	��200��$��20,0,0,0q����� $ 	UnitStats�$ OneWay=����� .R��� ���� *Name+$ OneWay=��� $ 
Horizontal=�$��0,5,0,0q�.+��� $��	Unit Type���� -   $, &typeOfUnitComboBox_addUnit_childWindow��$��5,0,0,0q�$	��100�� �� *
TypeOfUnit+  EnumTypeOfUnitIntConverter# [ $ OneWay=� �� $( "presetComboBox_addUnit_childWindow��$ SelectedItem�$ OneWay=�.@��� $�Space���� $�Ground���� $
�Both���� $ 
Horizontal=�$��0,5,0,0q�.+��� $
��Name���� -   $% nameTextBox_addUnit_childWindow��$	��170��$��43,0,0,0q����� $
 Name�$ OneWay=� �� $( "presetComboBox_addUnit_childWindow��$ SelectedItem�$ OneWay=��� $ 
Horizontal=�$��0,5,0,0q�.+��� $ 
Horizontal=�$��0,0,0,0q�.+��� $��Health���� -   $' !healthTextBox_addUnit_childWindow��$��40��$��40,0,0,0q����� *Health+$ OneWay=� �� $( "presetComboBox_addUnit_childWindow��$ SelectedItem�$ OneWay=��� $ 
Horizontal=�$��15,0,0,0q�.+��� $��Attack Value���� -   $, &attackValueTextBox_addUnit_childWindow��$��40��$��10,0,0,0q����� *AttackPower+$ OneWay=� �� $( "presetComboBox_addUnit_childWindow��$ SelectedItem�$ OneWay=��� -    ��Name$3 -commandAndControlCheckBox_addUnit_childWindow��$��Command and Control��$ FalseY�$��75,5,0,0q��� -   $* $detectedCheckBox_addUnit_childWindow��$��Detected��$��75,5,0,0q� �� *
Detected+ �� $( "presetComboBox_addUnit_childWindow��$ SelectedItem�$ OneWay=��� $ 
Horizontal=�$��0,20,0,0q�.+��� $��Quantity���� -   $) #quantityOfUnits_addUnit_childWindow��$��1��$��40��$��20,0,0,0q��� -   $��Submit��$��0,5,0,0q�