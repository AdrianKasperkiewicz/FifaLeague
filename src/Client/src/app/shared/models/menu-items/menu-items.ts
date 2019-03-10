import { Injectable } from '@angular/core';

export interface Menu {
  state: string;
  name: string;
  type: string;
  icon: string;
}

const MENUITEMS = [

  { state: '/starter', name: 'Start', type: 'link', icon: 'home' },
  { state: '/league/fixture', name: 'Terminarz', type: 'link', icon: 'today' },
  {
    state: '',
    name: 'Material Ui',
    type: 'sub',
    icon: 'bubble_chart',
    badge: [{ type: 'red', value: '17' }],
    children: [
      { state: '/button', type: 'link', name: 'Buttons', icon: 'crop_7_5' },
      { state: '/grid', type: 'link', name: 'Grid List', icon: 'view_comfy' },
      { state: '/lists', type: 'link', name: 'Lists', icon: 'view_list' },
      { state: '/menu', type: 'link', name: 'Menu', icon: 'view_headline' },
      { state: '/tabs', type: 'link', name: 'Tabs', icon: 'tab' },
      { state: '/stepper', type: 'link', name: 'Stepper', icon: 'web' },
      {
        state: '/expansion',
        type: 'link',
        name: 'Expansion Panel',
        icon: 'vertical_align_center'
      },
      { state: '/chips', type: 'link', name: 'Chips', icon: 'vignette' },
      { state: '/toolbar', type: 'link', name: 'Toolbar', icon: 'voicemail' },
      {
        state: '/progress-snipper',
        type: 'link',
        name: 'Progress snipper',
        icon: 'border_horizontal'
      },
      {
        state: '/progress',
        type: 'link',
        name: 'Progress Bar',
        icon: 'blur_circular'
      },
      {
        state: '/dialog',
        type: 'link',
        name: 'Dialog',
        icon: 'assignment_turned_in'
      },
      { state: '/tooltip', type: 'link', name: 'Tooltip', icon: 'assistant' },
      { state: '/snackbar', type: 'link', name: 'Snackbar', icon: 'adb' },
      { state: '/slider', type: 'link', name: 'Slider', icon: 'developer_mode' },
      {
        state: '/slide-toggle',
        type: 'link',
        name: 'Slide Toggle',
        icon: 'all_inclusive'
      }
    ]
  },
  {
    state: '',
    name: 'Ustawienia',
    type: 'sub',
    icon: 'settings',
    badge: [{ type: 'red', value: '3' }],
    children: [
      {
        state: '/settings/newseason',
        type: 'link',
        name: 'Ustawienia',
        icon: 'settings'
      },
      {
        state: '/settings/divisions',
        type: 'link',
        name: 'Dywizje',
        icon: 'tab'
      },
      {
        state: '/settings/teams',
        type: 'link',
        name: 'Zespoły',
        icon: 'people'
      },
      {
        state: '/settings/startseason',
        type: 'power_settings_new',
        name: 'Rozpocznij sezon',
        icon: 'people'
      }
    ]
  }
];

@Injectable()
export class MenuItems {
  getMenuitem(): Menu[] {
    return MENUITEMS;
  }
}
