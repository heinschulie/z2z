using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Z2Z
{
    /// <summary>
    /// The Z2ZDependancies type, returns whether a suitably descriptive object is found within session for current form to adequately define its contents
    /// </summary>
    public enum Z2ZDependancies
    {
        /// <summary>
        /// SessionTimeout - current session has timed out
        /// </summary>
        SessionTimeout,
        /// <summary>
        /// NotFound - object listed as suitably descriptive not found in session
        /// </summary>
        NotFound,
        /// <summary>
        /// Found - object listed as suitably descriptive  found in session
        /// </summary>
        Found
    }
    /// <summary>
    /// The ProviderSearch type, either by Key or by Area.
    /// </summary>
    public enum LanguageLevelRating
    {
        /// <summary>
        /// Level 0 (Undefined Performance) 
        /// Level of language performance is undefined   
        /// </summary>
        None = 0,
        /// <summary>
        /// Level 0+ (Minimal Performance) 
        /// Able to transfer very little information from one language into another, usually representing isolated words and/or phrases.  
        /// Accuracy is haphazard.  Constant oversight is required.
        /// </summary>
        MinimalLow = 1,
        /// <summary>
        /// Level 1 (Minimal Performance) 
        /// Able to make word by word transfers, not always with accuracy.  May be able to identify documents by their label or headings and 
        /// scan graphic materials, such as charts and diagrams, for items of specific interest.  Constant oversight and review of the 
        /// product are necessary.
        /// </summary>
        MinimalMedium = 2,
        /// <summary>
        /// Level 0+ (Minimal Performance) 
        /// Able to scan source language texts for specific categories, topics, key points and/or main ideas, generally rendering an accurate 
        /// report on these but often missing supporting facts and details.  Can to some extent render factual materials, such as records or 
        /// database entries, often relying on real‑world knowledge or familiarity with the subject matter.  Oversight and review of the product 
        /// are necessary.
        /// </summary>
        MinimalHigh = 3,
        /// <summary>
        /// Level 0+ (Minimal Performance) 
        /// Able to render into the target language some straightforward, factual texts in the standard variety of the source language.  
        /// Can typically render accurately uncomplicated prose (such as that used in short identification documents, simple letters, 
        /// instructions, and some narrative reports) that does not contain figurative language, complex sentence structures, embedding, 
        /// or instances of syntactic or semantic skewing.  Can normally rely on knowledge of the subject matter to operate within one 
        /// given subject field, consisting of a narrow body of material that is routine, repetitive, and often predictable.  
        /// Expression in the target language may be faulty, frequently reflecting the structure and word order of the source language.  
        /// To the extent that faulty expression may obscure or distort meaning, accuracy will suffer.  The resulting product is not a 
        /// professional translation and must be submitted to quality control.
        /// </summary>
        LimitedLow = 4,
        /// <summary>
        /// Level 0+ (Minimal Performance) 
        /// Can render straightforward texts dealing with everyday matters that include statements of fact as well as some judgments, 
        /// opinion, or other elements which entail more than direct exposition, but do not contain figurative language, complicated concepts, 
        /// complex sentence structures, or instances of syntactic or semantic skewing.  In these types of texts, the individual can read 
        /// source language materials and render them accurately into the target language, conveying the key points and/or main ideas, 
        /// supporting facts, most of the details, and some nuances.  Can usually operate in more than one narrowly defined subject field, 
        /// using both linguistic knowledge of the languages involved and familiarity with the subject matter.  A tendency to adhere to source 
        /// language structures may result in target language expressions that may appear to be correct but are awkward or perhaps unidiomatic.
        /// Such expressions may sometimes obscure meaning.  The resulting product is not a professional translation and must be subject to
        /// quality control.
        /// </summary>
        LimitedMedium = 5,
        /// <summary>
        /// Level 0+ (Minimal Performance) 
        /// Can translate texts that contain not only facts but also abstract language, showing an emerging ability to capture their intended 
        /// implications and many nuances.  Such texts usually contain situations and events which are subject to value judgments of a personal
        /// or institutional kind, as in some newspaper editorials, propaganda tracts, and evaluations of projects.  Linguistic knowledge of
        /// both the terminology and the means of expression specific to a subject field is strong enough to allow the translator to operate
        /// successfully within that field.  Word choice and expression generally adhere to target language norms and rarely obscure meaning.  
        /// The resulting product is a draft translation, subject to quality control.
        /// </summary>
        LimitedHigh = 6,
        /// <summary>
        /// Level 0+ (Minimal Performance) 
        /// Can generally translate a variety of texts, such as many scientific or financial reports, some legal documents and some colloquial
        /// writings.  Can convey the meaning of many socio‑cultural elements embedded in a text as well as most nuances and relatively 
        /// infrequent lexical and syntactic items of the source language.  Expression reflects target language norms and usage.  May be able
        /// to operate in fields outside areas of specialty.  The resulting product is a draft translation, subject to quality control.
        /// </summary>
        ProfessionalLow = 7,
        /// <summary>
        /// Level 0+ (Minimal Performance) 
        /// Can successfully apply a translation methodology to translate a wide variety of complex texts that contain difficult, abstract, 
        /// idiomatic, highly technical, and colloquial writing.  Able to capture subtleties, nuances, and tone and register (such as official,
        /// formal, and informal writing).  Such texts range from commentary reflecting a specific culture to analysis and argumentation.  
        /// Linguistic knowledge and familiarity with source language norms enable an individual at this level to translate handwritten 
        /// documents and other texts that represent spontaneous expression characteristic of native speakers.  Expression reflects native
        /// usage and consistent control of target language conventions.  Can translate materials outside the individual’s specialties, but may
        /// not reach the absolute subject matter accuracy of the specialist in the given field.  The resulting product is a professional 
        /// translation which may be subject to quality control.
        /// </summary>
        ProfessionalMedium = 8,
        /// <summary>
        /// Level 0+ (Minimal Performance) 
        /// Can successfully apply a translation methodology to translate texts that contain highly original and special purpose language 
        /// (such as that contained in religious sermons, literary prose, and poetry).  At this level, a successful performance requires not 
        /// only conveying content and register but also capturing to the greatest extent all nuances intended in the source document.  
        /// Expression is virtually flawless.  Can produce fully accurate translations in a number of subject fields.  When the need arises 
        /// to perform in areas outside of specialization, a translator at this level is able to reach a successful level of performance given 
        /// the time necessary for acquiring the relevant knowledge of the subject matter.  The resulting product is a professional translation
        /// which may be subject to quality control.
        /// </summary>
        ProfessionalHigh = 9,
        /// <summary>
        /// Level 0+ (Minimal Performance) 
        /// Can successfully translate virtually all texts, including those where lack of linguistic and cultural parallelism between the source
        /// language and the target language requires precise congruity judgments and the ability to apply a translation methodology.  
        /// Expression is flawless.  At this level, the translator consistently excels in a number of specialties, and is generally regarded as
        /// one of the arbiters of translating very high level language by persons competent in dealing with such material.  Nonetheless, the 
        /// resulting product may be subject to quality control.
        /// </summary>
        ProfessionalExpert = 10
    }
}
