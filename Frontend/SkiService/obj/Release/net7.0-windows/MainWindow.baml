   M S B A M L   `   `   `  ����   
SkiService    SkiService.MainWindow   W SPresentationCore, Version=7.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=7.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=7.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=7.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     R NSystem.Xaml, Version=7.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml       � Title$  Ski Service App��$	��450��$	��800��.��� .+�� -   $��	loginGrid�� � RowDefinitions �� $
��Auto ��� $��* �.+��� $��0�� �� Orientation$ 
Horizontal=�$��10q�.+��� $��Benutzername:��$��Center=�$��0,0,5,0q��� -   $��usernameTextBox��$	��120���� $��	Passwort:��$��Center=�$��10,0,5,0q�G� -   $��passwordBox��$	��120���� -   $��Login��$��10,0,0,0q�� -   $��adminFunctionsGrid��$y�	Collapsed=� �� $
��Auto ��� $��* �.+��� $��0��$ 
Horizontal=�$��Right=�$��10q�.+��� $��30��$��30��$��0,0,10,0q�����  �� Path$ AdminImageSource��� $��Center=����� $ CurrentAdminName�� $��1��$��10q�.+��� $ 
Horizontal=�$��0,0,0,10q�$	��Top=�.+��� $��Suche:��$��Center=�$��0,0,5,0q��� -   $��searchTextBox��$	��100���� -   $��Suchen��$��10,0,0,0q��� $
��Auto=�.���� -   $��serviceListView��$	��150��$��0,0,0,10q� �� View �� .P��� $��
Kundenname�� �� Width$	 150�� �� DisplayMemberBinding �� *
KundenName+�� $��Dienstleistung��$	 150�� �� *Dienstleistung+�� $��
Priorität��$	 100�� �� *
Prioritaet+�� $��Status��$	 100�� �� *Status+�� $��Right=�$��Bottom=�.+��� $ 
Horizontal=�$��Right=�$��0,10,1,0q�.+��� -	   $��Änderungen übernehmen���� -
   $��Änderungen speichern���� -   $��Auftrag löschen��