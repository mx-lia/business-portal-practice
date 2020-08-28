import { Component, OnInit, Optional, Inject } from '@angular/core';
import { FormGroup, FormBuilder, Validators } from '@angular/forms';

import { MatDialogRef, MAT_DIALOG_DATA } from '@angular/material/dialog';

import { UserDialogData } from '../../../shared/models/user-dialog-data.model';
import { ConfirmedValidator } from '../../../core/validators/confirmed.validator';
import { Roles } from '@app/modules/shared/models/roles.model';

@Component({
  selector: 'app-dialogbox',
  templateUrl: './dialogbox.component.html',
  styleUrls: ['./dialogbox.component.css']
})
export class DialogboxComponent implements OnInit {

  userForm: FormGroup;
  hidePassword = true;
  hideConfirmPassword = true;
  keys: string[];
  roles = Roles;
  selectedRole: string;

  constructor(
    private dialogRef: MatDialogRef<DialogboxComponent>,
    private formBuilder: FormBuilder,
    @Optional() @Inject(MAT_DIALOG_DATA) public data: UserDialogData) {
      this.keys = Object.keys(this.roles).filter(value => isNaN(Number(value)));
  }

  ngOnInit(): void {
    this.userForm = this.formBuilder.group({
      id: [this.data.user ? this.data.user.id : null, []],
      email: [this.data.user ? this.data.user.email : '', [Validators.required, Validators.email]],
      userName: [this.data.user ? this.data.user.userName : '', [Validators.required, Validators.minLength(3), Validators.maxLength(50)]],
      role: [this.data.user ? this.data.user.role : Roles.Admin, []],
      password: ['', this.data.action === 'Add' ? [Validators.required, Validators.minLength(6), Validators.maxLength(30)] : []],
      confirmPassword: ['', []]
    }, {
      validator: ConfirmedValidator('password', 'confirmPassword')
    });
  }

  submit(): void {
    this.dialogRef.close({ action: this.data.action, user: this.userForm.value });
  }
}
