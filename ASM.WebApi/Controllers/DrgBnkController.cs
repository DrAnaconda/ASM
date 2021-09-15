using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ASM.WebApi.Controllers
{
    [ApiController, Route("[controller]"), AllowAnonymous]
    public class DrgBnkController : ControllerBase
    {
        [HttpGet("packages/{fullNdc}")]
        public IActionResult GetPackage(string fullNdc)
        {
            return Ok(
                "{    \"package_ndc_code\": \"55566-1801-01\",    \"originator_package_ndc_code\": \"55566-1801-1\",    \"description\": \"1 KIT IN 1 CARTON\",    \"full_description\": \"1 KIT IN 1 CARTON * 1 INJECTION, POWDER, LYOPHILIZED, FOR SOLUTION IN 1 VIAL * 5 mL IN 1 VIAL\",    \"amount\": \"1\",    \"unit\": \"1\",    \"form\": \"CARTON\",    \"for_product\": {        \"ndc_product_code\": \"55566-1801\",        \"originator_ndc_product_code\": \"55566-1801\",        \"name\": \"Zomacton\",        \"active_ingredients\": [            {                \"name\": \"SOMATROPIN\",                \"unii\": \"NQX9KB6PCL\",                \"strength_number\": \"5\",                \"strength_unit\": \"mg/1\"            }        ],        \"inactive_ingredients\": [            {                \"name\": \"MANNITOL\",                \"unii\": \"3OWL53L36A\",                \"strength_number\": \"30\",                \"strength_unit\": \"mg/1\"            },            {                \"name\": \"WATER\",                \"unii\": \"059QF0KO0R\",                \"strength_number\": null,                \"strength_unit\": null            },            {                \"name\": \"BENZYL ALCOHOL\",                \"unii\": \"LKG8494WBH\",                \"strength_number\": null,                \"strength_unit\": null            },            {                \"name\": \"SODIUM CHLORIDE\",                \"unii\": \"451W47IQ8X\",                \"strength_number\": null,                \"strength_unit\": null            }        ]    },    \"parts\": [        {            \"number\": 1,            \"ndc_product_code\": null,            \"originator_ndc_product_code\": null,            \"name\": \"ZOMACTON\",            \"route\": \"SUBCUTANEOUS\",            \"amount\": \"1\",            \"unit\": \"1\",            \"dosage_form\": \"INJECTION, POWDER, LYOPHILIZED, FOR SOLUTION\",            \"marketing_category\": \"BLA\",            \"application_number\": \"BLA019774\",            \"packaging_tree\": [                {                    \"package_ndc_code\": null,                    \"originator_package_ndc_code\": null,                    \"description\": \"1 INJECTION, POWDER, LYOPHILIZED, FOR SOLUTION IN 1 VIAL\",                    \"amount\": \"1\",                    \"unit\": \"1\",                    \"form\": \"VIAL\"                }            ],            \"active_ingredients\": [                {                    \"name\": \"SOMATROPIN\",                    \"unii\": \"NQX9KB6PCL\",                    \"strength_number\": \"5\",                    \"strength_unit\": \"mg/1\"                }            ],            \"inactive_ingredients\": [                {                    \"name\": \"MANNITOL\",                    \"unii\": \"3OWL53L36A\",                    \"strength_number\": \"30\",                    \"strength_unit\": \"mg/1\"                }            ]        },        {            \"number\": 2,            \"ndc_product_code\": null,            \"originator_ndc_product_code\": null,            \"name\": \"STERILE DILUENT\",            \"route\": \"SUBCUTANEOUS\",            \"amount\": \"5\",            \"unit\": \"mL\",            \"dosage_form\": \"SOLUTION\",            \"marketing_category\": \"BLA\",            \"application_number\": \"BLA019774\",            \"packaging_tree\": [                {                    \"package_ndc_code\": null,                    \"originator_package_ndc_code\": null,                    \"description\": \"5 mL IN 1 VIAL\",                    \"amount\": \"5\",                    \"unit\": \"mL\",                    \"form\": \"VIAL\"                }            ],            \"active_ingredients\": [],            \"inactive_ingredients\": [                {                    \"name\": \"WATER\",                    \"unii\": \"059QF0KO0R\",                    \"strength_number\": null,                    \"strength_unit\": null                },                {                    \"name\": \"BENZYL ALCOHOL\",                    \"unii\": \"LKG8494WBH\",                    \"strength_number\": null,                    \"strength_unit\": null                },                {                    \"name\": \"SODIUM CHLORIDE\",                    \"unii\": \"451W47IQ8X\",                    \"strength_number\": null,                    \"strength_unit\": null                }            ]        }    ],    \"packaging_tree\": [        {            \"package_ndc_code\": \"55566-1801-01\",            \"originator_package_ndc_code\": \"55566-1801-1\",            \"description\": \"1 KIT IN 1 CARTON\",            \"amount\": \"1\",            \"unit\": \"1\",            \"form\": \"CARTON\"        }    ]}");
        }

        [HttpGet("products/{productNdc}")]
        public IActionResult GetProducts(string productNdc)
        {
            return Ok(
                "{    \"ndc_product_code\": \"55566-1801\",    \"originator_ndc_product_code\": \"55566-1801\",    \"dpd_id\": null,    \"ema_product_code\": null,    \"ema_ma_number\": null,    \"name\": \"Zomacton\",    \"prescribable_name\": \"Zomacton 5 mg Subcutaneous\",    \"rx_norm_prescribable_name\": \"ZOMACTON 5 MG/ML Injectable Solution\",    \"started_marketing_on\": \"1995-05-25\",    \"ended_marketing_on\": null,    \"approved_on\": null,    \"schedule\": null,    \"dosage_form\": \"\",    \"route\": \"Subcutaneous\",    \"application_number\": \"BLA019774\",    \"generic\": false,    \"otc\": false,    \"approved\": true,    \"country\": \"US\",    \"mixture\": false,    \"allergenic\": false,    \"cosmetic\": false,    \"vaccine\": false,    \"ingredients\": [        {            \"drug\": {                \"drugbank_id\": \"DB00052\",                \"name\": \"Somatotropin\",                \"cas_number\": \"12629-01-5\",                \"annotation_status\": \"complete\",                \"availability_by_region\": [                    {                        \"region\": \"ca\",                        \"max_phase\": 4,                        \"marketed_prescription\": true,                        \"generic_available\": false,                        \"pre_market_cancelled\": false,                        \"post_market_cancelled\": false                    },                    {                        \"region\": \"eu\",                        \"max_phase\": 4,                        \"marketed_prescription\": true,                        \"generic_available\": false,                        \"pre_market_cancelled\": false,                        \"post_market_cancelled\": false                    },                    {                        \"region\": \"us\",                        \"max_phase\": 4,                        \"marketed_prescription\": true,                        \"generic_available\": false,                        \"pre_market_cancelled\": false,                        \"post_market_cancelled\": false                    }                ],                \"description\": \"Human growth hormone (HGH), also known as somatotropin, is a peptide hormone that is synthesized and secreted by the somatotropic cells of the anterior pituitary gland.[A228183] Growth hormone plays an essential role in growth regulation during childhood as well as other basal metabolic functions, muscle and fat mass regulation, blood glucose level regulation, and lipid regulation in both children and adults.[A228183, L31508] Synthesized in a strain of _Escherichia coli_, recombinant HGH is a polypeptide hormone that contains 191 amino acid residues with a molecular weight of 22 kDa. It has an identical primary protein structure to endogenous human growth hormone.[A228188] Recombinant HGH has been commercially available since 1985 after its development by Genentech. [Somatrem] was the first available recombinant HGH and was largely replaced by somatropin, another form of recombinant HGH.[A228183] \r\n\r\nGrowth hormone therapy is approved for various disorders of growth hormone deficiency, growth failure, or short stature including Turner syndrome, chronic renal insufficiency before transplantation, Prader-Willi syndrome, a history of fetal growth restriction, short stature homeobox (SHOX) haploinsufficiency, Noonan syndrome, idiopathic short stature, and adult- or childhood-onset growth hormone deficiency.[A228188] Recombinant growth hormone is available as a subcutaneous injection for children and adults under a wide variety of brand names.\",                \"simple_description\": \"A medication used to stimulate growth in children and treat a wide variety of conditions of growth hormone deficiency and inadequate nutrition in children and adults.\",                \"clinical_description\": \"A recombinant human growth hormone used as replacement therapy in various conditions of growth failure, growth hormone deficiency, and weakness in children and adults.\",                \"synonyms\": [                    \"Growth hormone\",                    \"Growth hormone (human)\",                    \"hGH\",                    \"Human growth hormone\",                    \"Recombinant human growth hormone\",                    \"rhGH\",                    \"Somatotropin (human)\",                    \"Somatotropin human\",                    \"Somatotropin human growth hormone\",                    \"Somatropin\",                    \"Somatropin (rDNA origin)\",                    \"Somatropin (recombinant DNA origin)\",                    \"Somatropin [rDNA origin]\",                    \"Somatropin recombinant\",                    \"Somatropin(recombinant DNA origin)\",                    \"Somatropina\"                ],                \"food_interactions\": [],                \"identifiers\": {                    \"drugbank_id\": \"DB00052\",                    \"inchi\": null,                    \"inchikey\": null,                    \"atc_codes\": [                        {                            \"code\": \"H01AC01\",                            \"title\": \"somatropin\",                            \"combination\": false                        }                    ]                },                \"therapeutic_categories\": [                    {                        \"drugbank_id\": \"DBCAT000021\",                        \"name\": \"Amino Acids, Peptides, and Proteins\",                        \"mesh_id\": \"D000602\",                        \"mesh_tree_numbers\": [                            \"D12\"                        ],                        \"atc_code\": null,                        \"atc_level\": null,                        \"synonyms\": [],                        \"description\": \"Amino acids and chains of amino acids connected by peptide linkages.\"                    },                    {                        \"drugbank_id\": \"DBCAT003608\",                        \"name\": \"Pituitary\",                        \"mesh_id\": null,                        \"mesh_tree_numbers\": [],                        \"atc_code\": null,                        \"atc_level\": null,                        \"synonyms\": [],                        \"description\": null                    },                    {                        \"drugbank_id\": \"DBCAT003261\",                        \"name\": \"Recombinant Human Growth Hormone\",                        \"mesh_id\": null,                        \"mesh_tree_numbers\": [],                        \"atc_code\": null,                        \"atc_level\": null,                        \"synonyms\": [],                        \"description\": null                    },                    {                        \"drugbank_id\": \"DBCAT003614\",                        \"name\": \"Somatotropin Agonists\",                        \"mesh_id\": null,                        \"mesh_tree_numbers\": [],                        \"atc_code\": null,                        \"atc_level\": null,                        \"synonyms\": [                            \"Bovine somatotropin derivatives\",                            \"Porcine somatotropin derivatives\",                            \"Somatotropin Agonists*\"                        ],                        \"description\": null                    }                ],                \"references\": {                    \"literature_references\": [                        {                            \"ref_id\": \"A228183\",                            \"pubmed_id\": 22291494,                            \"citation\": \"Reh CS, Geffner ME: Somatotropin in the treatment of growth hormone deficiency and Turner syndrome in pediatric patients: a review. Clin Pharmacol. 2010;2:111-22. doi: 10.2147/CPAA.S6525. Epub 2010 Jun 1.\"                        },                        {                            \"ref_id\": \"A228188\",                            \"pubmed_id\": 29197220,                            \"citation\": \"Mehta S, Oza V, Potashner R, Zamora P, Raisingani M, Shah B: Allergic and non-allergic skin reactions associated with growth hormone therapy: elucidation of causative agents. J Pediatr Endocrinol Metab. 2018 Jan 26;31(1):5-11. doi: 10.1515/jpem-2017-0309.\"                        },                        {                            \"ref_id\": \"A228388\",                            \"pubmed_id\": 3047155,                            \"citation\": \"Glenn KC, Rose KS, Krivi GG: Somatotropin antagonism of insulin-stimulated glucose utilization in 3T3-L1 adipocytes. J Cell Biochem. 1988 Aug;37(4):371-83. doi: 10.1002/jcb.240370405.\"                        },                        {                            \"ref_id\": \"A228398\",                            \"pubmed_id\": 29025199,                            \"citation\": \"Kim SH, Park MJ: Effects of growth hormone on glucose metabolism and insulin resistance in human. Ann Pediatr Endocrinol Metab. 2017 Sep;22(3):145-152. doi: 10.6065/apem.2017.22.3.145. Epub 2017 Sep 28.\"                        },                        {                            \"ref_id\": \"A228403\",                            \"pubmed_id\": 17634080,                            \"citation\": \"Langbakke IH, Nielsen JN, Skettrup MP, Harper A, Klitgaard T, Weil A, Engelhardt E, Lange M: Pharmacokinetics and pharmacodynamics of growth hormone in patients on chronic haemodialysis compared with matched healthy subjects: an open, nonrandomized, parallel-group trial. Clin Endocrinol (Oxf). 2007 Nov;67(5):776-83. doi: 10.1111/j.1365-2265.2007.02962.x. Epub 2007 Jul 18.\"                        },                        {                            \"ref_id\": \"A228463\",                            \"pubmed_id\": 2380341,                            \"citation\": \"Baumann G, Vance ML, Shaw MA, Thorner MO: Plasma transport of human growth hormone in vivo. J Clin Endocrinol Metab. 1990 Aug;71(2):470-3. doi: 10.1210/jcem-71-2-470.\"                        }                    ],                    \"textbooks\": [],                    \"external_links\": [                        {                            \"ref_id\": \"L10971\",                            \"title\": \"FDA Approved Drug Products: Norditropin (somatropin) injection, for subcutaneous use\",                            \"url\": \"https://www.accessdata.fda.gov/drugsatfda_docs/label/2017/021148s049lbl.pdf\"                        },                        {                            \"ref_id\": \"L31493\",                            \"title\": \"FDA Approved Drug Products: ZORBTIVE (somatropin) for injection, for subcutaneous use\",                            \"url\": \"https://www.accessdata.fda.gov/drugsatfda_docs/label/2017/020604s074lbl.pdf\"                        },                        {                            \"ref_id\": \"L31498\",                            \"title\": \"FDA Approved Drug Products: SEROSTIM (somatropin) for injection, for subcutaneous use\",                            \"url\": \"https://www.accessdata.fda.gov/drugsatfda_docs/label/2017/020604s093lbl.pdf\"                        },                        {                            \"ref_id\": \"L31508\",                            \"title\": \"StatPearls: Physiology, Growth Hormone\",                            \"url\": \"https://www.ncbi.nlm.nih.gov/books/NBK482141/\"                        },                        {                            \"ref_id\": \"L31513\",                            \"title\": \"FDA Approved Drug Products: ZOMACTON (somatropin) for injection, for subcutaneous use\",                            \"url\": \"https://www.accessdata.fda.gov/drugsatfda_docs/label/2018/180717s048s049s050s051lbl.pdf\"                        },                        {                            \"ref_id\": \"L31518\",                            \"title\": \"FDA Approved Drug Products: GENOTROPIN (somatropin) for injection, for subcutaneous use\",                            \"url\": \"https://www.accessdata.fda.gov/drugsatfda_docs/label/2020/020280s090lbl.pdf\"                        },                        {                            \"ref_id\": \"L31523\",                            \"title\": \"FDA Approved Drug Products: Nutropin (somatropin) injection, for subcutaneous use\",                            \"url\": \"https://www.accessdata.fda.gov/drugsatfda_docs/label/2016/019676s044,020168s024lbl.pdf\"                        },                        {                            \"ref_id\": \"L31528\",                            \"title\": \"Pfizer: Genotropin (Somatropin) Safety Data Sheet\",                            \"url\": \"https://pfe-pfizercom-prod.s3.amazonaws.com/products/material_safety_data/Somatropin_for_inj_06-2mg_15-March-2018.pdf\"                        }                    ],                    \"attachments\": []                }            },            \"strength\": {                \"number\": \"5\",                \"unit\": \"mg/1\"            }        }    ],    \"therapeutic_categories\": [        {            \"drugbank_id\": \"DBCAT000021\",            \"name\": \"Amino Acids, Peptides, and Proteins\",            \"mesh_id\": \"D000602\",            \"mesh_tree_numbers\": [                \"D12\"            ],            \"atc_code\": null,            \"atc_level\": null,            \"synonyms\": [],            \"description\": \"Amino acids and chains of amino acids connected by peptide linkages.\"        },        {            \"drugbank_id\": \"DBCAT003261\",            \"name\": \"Recombinant Human Growth Hormone\",            \"mesh_id\": null,            \"mesh_tree_numbers\": [],            \"atc_code\": null,            \"atc_level\": null,            \"synonyms\": [],            \"description\": null        },        {            \"drugbank_id\": \"DBCAT003608\",            \"name\": \"Pituitary\",            \"mesh_id\": null,            \"mesh_tree_numbers\": [],            \"atc_code\": null,            \"atc_level\": null,            \"synonyms\": [],            \"description\": null        },        {            \"drugbank_id\": \"DBCAT003614\",            \"name\": \"Somatotropin Agonists\",            \"mesh_id\": null,            \"mesh_tree_numbers\": [],            \"atc_code\": null,            \"atc_level\": null,            \"synonyms\": [                \"Bovine somatotropin derivatives\",                \"Porcine somatotropin derivatives\",                \"Somatotropin Agonists*\"            ],            \"description\": null        }    ],    \"labeller\": {        \"name\": \"Ferring Pharmaceuticals Inc.\"    },    \"images\": []}");
        }

        [HttpGet("conditions")]
        public IActionResult Conditions()
        {
            return Ok(
                "[    {        \"name\": \"ER+ and AR+ Breast Cancer\",        \"drugbank_id\": \"DBCOND0074929\",        \"uniprot_id\": null,        \"icd10_id\": null    },    {        \"name\": \"Primary Breast Cancer AR+ve TNBN\",        \"drugbank_id\": \"DBCOND0078365\",        \"uniprot_id\": null,        \"icd10_id\": null    },    {        \"name\": \"Acute Rejection (AR) of Transplanted Kidney\",        \"drugbank_id\": \"DBCOND0056337\",        \"uniprot_id\": null,        \"icd10_id\": null    },    {        \"name\": \"Rhinitis, Allergic\",        \"drugbank_id\": \"DBCOND0041847\",        \"uniprot_id\": null,        \"icd10_id\": \"c/J30.9\"    },    {        \"name\": \"Rhinitis Allergic\",        \"drugbank_id\": \"DBCOND0035656\",        \"uniprot_id\": null,        \"icd10_id\": \"c/J30.9\"    },    {        \"name\": \"Allergic Rhinitis (AR)\",        \"drugbank_id\": \"DBCOND0053380\",        \"uniprot_id\": null,        \"icd10_id\": \"c/J30.9\"    },    {        \"name\": \"Allergic Rhinitis\",        \"drugbank_id\": \"DBCOND0029366\",        \"uniprot_id\": null,        \"icd10_id\": \"c/J30.9\"    },    {        \"name\": \"Allergic Rhinitis (Disorder)\",        \"drugbank_id\": \"DBCOND0040015\",        \"uniprot_id\": null,        \"icd10_id\": \"c/J30.9\"    },    {        \"name\": \"Rhinitis,Allergic\",        \"drugbank_id\": \"DBCOND0078695\",        \"uniprot_id\": null,        \"icd10_id\": \"c/J30.9\"    }]");
        }
    }
}