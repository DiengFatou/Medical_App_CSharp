<?php

namespace Database\Seeders;

use App\Models\User;
use App\Models\Soin;

// use Illuminate\Database\Console\Seeds\WithoutModelEvents;
use Illuminate\Database\Seeder;

class DatabaseSeeder extends Seeder
{
    /**
     * Seed the application's database.
     */
    public function run(): void
    {
        Soin::factory(10)->create();

    }
}
