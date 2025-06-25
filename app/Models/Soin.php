<?php

namespace App\Models;

use Illuminate\Database\Eloquent\Model;
use Illuminate\Database\Eloquent\Factories\HasFactory; 

class Soin extends Model
{
     use HasFactory;

    protected $table = 'soins'; // ou 'soin' selon ton cas
    protected $primaryKey = 'IdSoin'; // si c’est bien ça ta clé

    protected $fillable = ['Libelle'];

    public $timestamps = false;
}
