<?php

namespace App\Http\Controllers\Api;

use App\Http\Controllers\Controller;
use App\Models\Soin;
use Illuminate\Http\Request;

class SoinController extends Controller
{
    /**
     * Display a listing of the resource.
     */
    public function index()
    {
        return response()->json(Soin::all());

    }

    /**
     * Store a newly created resource in storage.
     */
    public function store(Request $request)
    {
         $validated = $request->validate([
        'Libelle' => 'required|string|max:255',
       
    ]);

    // Creation
    $etudiant = Soin::create([
        'Libelle' => $validated['Libelle'],
       
    ]);

    return response()->json($etudiant, 201);

    }

    /**
     * Display the specified resource.
     */
    public function show(string $IdSoin)
    {
        return response()->json(Soin::findOrFail($IdSoin));

    }

    /**
     * Update the specified resource in storage.
     */
    public function update(Request $request, string $IdSoin)
    {
        // Recuperation de  l'etudiant a modifier
        $soin = SOin::findOrFail($IdSoin);

    // Validation
        $validated = $request->validate([
            'Libelle' => 'required|string|max:255',
        
        ]);

   
        // Mettre a jour les champs
        $soin->update([
            'Libelle' => $validated['Libelle'],
         
        ]);

        // Redirection ou retourner une reponse
        return response()->json([
            'message'=>'success', 'Étudiant mis à jour avec succès', $soin
        ]);
    }

    /**
     * Remove the specified resource from storage.
     */
    public function destroy(string $IdSoin)
    {
        Soin::findOrFail($IdSoin)->delete();
    }
}
